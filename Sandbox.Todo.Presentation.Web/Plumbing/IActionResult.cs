namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System;

    public interface IActionResult
    {
        string Perform(string rawUrl, Route route, Action<string> redirect);
    }
}