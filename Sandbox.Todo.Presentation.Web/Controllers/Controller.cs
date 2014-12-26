namespace Sandbox.Todo.Presentation.Web.Controllers
{
    using System;
    using System.Collections.Specialized;

    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Web.Plumbing;
    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;
    using Sandbox.Todo.Presentation.Web.Views;

    public class Controller
    {
        private readonly ITodoService todoService;

        public Controller(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        public IActionResult Index(NameValueCollection arg)
        {
            var todos = this.todoService.GetAll();
            return new TodoView(todos);
        }

        public IActionResult Add(NameValueCollection arg)
        {
            this.todoService.Add(arg["text"]);
            return new Redirect(this.Index);
        }

        public IActionResult Remove(NameValueCollection arg)
        {
            this.todoService.Remove(new TodoId(new Guid(arg["id"])));
            return new Redirect(this.Index);
        }

        public IActionResult SetPriority(NameValueCollection arg)
        {
            return new Redirect(this.Index);
        }
    }
}
