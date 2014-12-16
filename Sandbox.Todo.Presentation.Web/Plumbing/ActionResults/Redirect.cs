namespace Sandbox.Todo.Presentation.Web.Plumbing.ActionResults
{
    using System;
    using System.Collections.Specialized;

    public class Redirect : IActionResult
    {
        private readonly Func<NameValueCollection, IActionResult> action;

        public Redirect(Func<NameValueCollection, IActionResult> action)
        {
            this.action = action;
        }

        public string Perform(string rawUrl, Route route, Action<string> redirect)
        {
            var url = route.ReverseRoute(this.action);
            redirect(url);
            return string.Empty;
        }
    }
}