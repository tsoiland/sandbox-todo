namespace Sandbox.Todo.Presentation.Web
{
    using System.Collections.Specialized;

    using Sandbox.Todo.Presentation.Web.Content;
    using Sandbox.Todo.Presentation.Web.Controllers;

    public class OuterRouter
    {
        private readonly ControllerRoute controllerRoute;

        private readonly ContentRoute contentRoute;

        public OuterRouter(ControllerRoute controllerRoute, ContentRoute contentRoute)
        {
            this.controllerRoute = controllerRoute;
            this.contentRoute = contentRoute;
        }

        public string Invoke(string rawUrl, NameValueCollection arg)
        {
            if (this.controllerRoute.HasMatch(rawUrl))
            {
                return this.controllerRoute.Invoke(rawUrl, arg);
            }

            return this.contentRoute.Invoke(rawUrl, arg);
        }
    }
}