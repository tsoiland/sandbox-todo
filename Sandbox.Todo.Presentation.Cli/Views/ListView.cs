namespace Sandbox.Todo.Presentation.Cli.Views
{
    using System.Collections.Generic;
    using System.Text;

    using Sandbox.Todo.Presentation.Cli.ViewModels;

    public class ListView : IView
    {
        private readonly IList<TodoViewModel> todos;

        public ListView(IList<TodoViewModel> todos)
        {
            this.todos = todos;
        }

        public string Render()
        {
            var result = new StringBuilder();

            result.AppendLine("Todos:");
            result.AppendLine("-------");
            foreach (var todo in this.todos)
            {
                result.AppendLine(this.RenderOneLine(todo));
            }
            result.AppendLine("-------");

            return result.ToString();

        }

        private string RenderOneLine(TodoViewModel todo)
        {
            return todo.LineNumber.PadRight(2, ' ') + " " + todo.Text;
        }
    }
}