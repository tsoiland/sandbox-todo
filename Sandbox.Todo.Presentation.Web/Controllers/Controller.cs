namespace Sandbox.Todo.Presentation.Web.Controllers
{
    using System;
    using System.Collections.Specialized;

    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Web.Views;

    public class Controller
    {
        private readonly ITodoService todoService;

        public Controller(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        public IView Index(NameValueCollection arg)
        {
            var todos = this.todoService.GetAll();
            return new TodoView(todos);
        }

        public IView Add(NameValueCollection arg)
        {
            this.todoService.Add(arg["text"]);
            return new Redirect(() => this.Index(arg));
        }

        public IView Remove(NameValueCollection arg)
        {
            this.todoService.Remove(new TodoId(new Guid(arg["id"])));
            return new Redirect(() => this.Index(arg));
        }

        public IView SetPriority(NameValueCollection arg)
        {
            return new Redirect(() => this.Index(arg));
        }

        public IView css(NameValueCollection arg)
        {
            return new CssView();
        }
    }

    public class CssView : IView
    {
        public string Render()
        {
            return @"
                body {
                    background-color: red;
                }
            ";
        }
    }
}
