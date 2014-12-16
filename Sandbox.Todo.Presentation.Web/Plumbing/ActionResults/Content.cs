namespace Sandbox.Todo.Presentation.Web.Plumbing.ActionResults
{
    using System;
    using System.IO;

    public class Content : IActionResult
    {
        public string Perform(string rawUrl, Route route, Action<string> redirect)
        {
            var url = rawUrl.TrimStart('/');
            using (var sr = new StreamReader(url))
            {
                return sr.ReadToEnd();
            }
        }
    }
}