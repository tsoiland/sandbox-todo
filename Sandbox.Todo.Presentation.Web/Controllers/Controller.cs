namespace Sandbox.Todo.Presentation.Web.Controllers
{
    using System.Collections.Specialized;

    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Web.Plumbing;
    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;
    using Sandbox.Todo.Presentation.Web.Plumbing.ViewHelpers;
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
            this.todoService.Remove(new TodoId(arg["id"]));
            return new Redirect(this.Index);
        }

        public IActionResult SetPriorityForm(NameValueCollection arg)
        {
            var todoId = new TodoId(arg["id"]);
            var options = new[] { 1, 2, 3, 4, 5 };

            var selectListValues = SelectListValues.New("priority", options);

            return new SetPriorityView(todoId, selectListValues);
        }

        public IActionResult SetPriority(NameValueCollection arg)
        {
            var todoId = new TodoId(arg["id"]);
            var priority = int.Parse(arg["priority"]);

            this.todoService.SetPriority(todoId, priority);

            return new Redirect(this.Index);
        }
    }
}
