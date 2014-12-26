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
            return @"
                <h2>An error has occured</h2>
                <p>" + this.exception.Message + @"</p>
                <p>" + this.exception.StackTrace + "</p>";
        }
    }
}