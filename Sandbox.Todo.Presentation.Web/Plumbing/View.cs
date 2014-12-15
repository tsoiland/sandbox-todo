namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System;

    using Sandbox.Todo.Presentation.Web.Views;

    public abstract class View : IActionResult
    {
        public string Perform(string rawUrl, Route route, Action<string> redirect)
        {
            return new Layout(this).Render();
        }

        public abstract string Render();
    }
}