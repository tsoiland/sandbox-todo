namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System;
    using System.Collections.Specialized;

    public class OuterRouter
    {
        private readonly Route route;

        private readonly ContentRoute contentRoute;

        public OuterRouter(Route route, ContentRoute contentRoute)
        {
            this.route = route;
            this.contentRoute = contentRoute;
        }

        public string Invoke(string rawUrl, NameValueCollection arg, Action<string> redirect)
        {
            if (this.route.HasMatch(rawUrl))
            {
                return this.route.Invoke(rawUrl, arg, redirect);
            }

            return this.contentRoute.Invoke(rawUrl, arg);
        }
    }
}