namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using Sandbox.Todo.Presentation.Web.Controllers;
    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;
    using Sandbox.Todo.Presentation.Web.Views;

    public class Route
    {
        private readonly Dictionary<string, Func<NameValueCollection, IActionResult>> route;

        public Route(Controller controller)
        {
            this.route = new Dictionary<string, Func<NameValueCollection, IActionResult>>
                {
                    { "/controller/index", controller.Index },
                    { "/controller/add", controller.Add },
                    { "/controller/remove", controller.Remove },
                    { "/controller/setpriority", controller.SetPriority },

                    { "/Content/style.css", _ => new Content()}
                };
        }

        public string Invoke(string rawUrl, NameValueCollection arg, Action<string> redirect)
        {
            var actionName = rawUrl.Split('?')[0];
            var action = this.route[actionName];
            try
            {
                var view = action.Invoke(arg);
                return view.Perform(rawUrl, this, redirect);
            }
            catch (Exception e)
            {
                return new ErrorView(e).Render();
            }
        }

        public string ReverseRoute(Func<NameValueCollection, IActionResult> action)
        {
            return this.route.Single(r => r.Value == action).Key;

        }
    }
}