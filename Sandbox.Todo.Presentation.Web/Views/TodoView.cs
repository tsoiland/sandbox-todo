namespace Sandbox.Todo.Presentation.Web.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using Sandbox.Todo.Application.Interface;

    public class TodoView : IView
    {
        private readonly IList<TodoDto> todos;

        public TodoView(IList<TodoDto> todos)
        {
            this.todos = todos;
        }

        public string Render()
        {
            return @"
                <h1>Todo list:</h1>
                <ul>" + 
                   this.RenderTodos()
                   + @"
                </ul>
                <form method='post' action='/contr/add'>
                    <input type='text' name='text' autofocus />
                    <input type='submit' value='Add' />
                </form>";
        }

        private string RenderTodos()
        {
            return string.Join("\n", this.todos.Select(t => "<li>" + t.Text + "</li>"));
        }
    }
}