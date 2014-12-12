namespace Sandbox.Todo.Presentation.Web.Views
{
    using System;

    public class Redirect : IView
    {
        private readonly Func<IView> action;

        public Redirect(Func<IView> action)
        {
            this.action = action;
        }

        public string Render()
        {
            return this.action.Invoke().Render();
        }
    }
}