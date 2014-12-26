namespace Sandbox.Todo.Presentation.Web.Views
{
    using System;

    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;

    public class ErrorView : View
    {
        private readonly Exception exception;

        public ErrorView(Exception exception)
        {
            this.exception = exception;
        }

        public override string Render()
        {
            return this.exception.Message;
        }
    }
}