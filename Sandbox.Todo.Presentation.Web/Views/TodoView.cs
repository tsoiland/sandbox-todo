namespace Sandbox.Todo.Presentation.Web.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            var sb = new StringBuilder();
            foreach (var todo in todos)
            {
                sb.AppendFormat("<li>{0}<a href='/contr/remove?id={1}'>X</a></li>", todo.Text, todo.Id);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}