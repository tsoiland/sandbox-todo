﻿namespace Sandbox.Todo.Presentation.Web.Views
{
    using System.Collections.Generic;
    using System.Text;

    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Web.Plumbing;

    public class TodoView : View
    {
        private readonly IList<TodoDto> todos;

        public TodoView(IList<TodoDto> todos)
        {
            this.todos = todos;
        }

        public override string Render()
        {
            return @"
                <h1>Todo list:</h1>
                <ul>" + 
                   this.RenderTodosAsLIs()
                   + @"
                </ul>
                <form method='post' action='/contr/add'>
                    <input type='text' name='text' autofocus />
                    <input type='submit' value='Add' />
                </form>";
        }

        private string RenderTodosAsLIs()
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