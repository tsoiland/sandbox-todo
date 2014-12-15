namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using Sandbox.Todo.Presentation.Web.Controllers;

    public class Route
    {
        private readonly Dictionary<string, Func<NameValueCollection, IActionResult>> route;

        public Route(Controller controller)
        {
            this.route = new Dictionary<string, Func<NameValueCollection, IActionResult>>
                              {
                                  { "index", controller.Index },
                                  { "add", controller.Add },
                                  { "remove", controller.Remove },
                                  { "setpriority", controller.SetPriority }
                              };
        }

        public bool HasMatch(string rawUrl)
        {
            var actionName = ParseAction(rawUrl);
            return actionName != null && this.route.ContainsKey(actionName);
        }

        private static string ParseAction(string rawUrl)
        {
            var a = rawUrl.Split('?')[0].Split('/');
            var actionName = a[2];
            return actionName;
        }

        public string Invoke(string rawUrl, NameValueCollection arg, Action<string> redirect)
        {
            var actionName = ParseAction(rawUrl);
            var action = this.route[actionName];
            var view = action.Invoke(arg);
            return view.Perform(rawUrl, this, redirect);
        }

        public string ReverseRoute(Func<NameValueCollection, IActionResult> action)
        {
            return "/contr/" + this.route.Single(r => r.Value == action).Key;

        }
    }
}