namespace Sandbox.Todo.Presentation.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Sandbox.Todo.Presentation.Web.Views;

    public class ControllerRoute
    {
        private readonly Dictionary<string, Func<NameValueCollection, IView>> route;

        public ControllerRoute(Controller controller)
        {
            this.route = new Dictionary<string, Func<NameValueCollection, IView>>
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
            return new Layout(view).Render();
        }
    }
}