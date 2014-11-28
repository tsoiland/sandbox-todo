namespace Sandbox.Todo.Presentation.Cli.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Cli.ViewModels;
    using Sandbox.Todo.Presentation.Cli.Views;

    /// <summary>
    /// The responsibility of this class is to translate between the user interface and the API.
    /// This goes for both parsing raw data and handleing some UI conserns.
    /// </summary>
    public class Controller
    {
        private readonly ITodoService todoService;
        private IDictionary<int, TodoId> lineNumberTodoIdMap;

        public Controller(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        public IView Add(IList<string> args)
        {
            var todotext = string.Join(" ", args);
            this.todoService.Add(todotext);
            return new BlankView();
        }

        public IView List(IList<string> args)
        {
            var todos = this.todoService.GetAll();

            var i = 1;
            this.lineNumberTodoIdMap = todos.ToDictionary(t => i++, t => t.Id);

            var viewModels = todos
                .Select(t => new TodoViewModel(
                    this.lineNumberTodoIdMap.Single(a => a.Value == t.Id).Key, 
                    t.Text))
                .ToList();
            return new ListView(viewModels);
        }

        public IView SetPriority(IList<string> args)
        {
            var intId = int.Parse(args.First());
            var todoId = this.lineNumberTodoIdMap[intId];
            var priority = int.Parse(args.ElementAt(1));

            this.todoService.SetPriority(todoId, priority);

            return new BlankView();
        }

        public IView Remove(IList<string> args)
        {
            var intId = int.Parse(args.First());
            var todoId = this.lineNumberTodoIdMap[intId];

            this.todoService.Remove(todoId);

            return new BlankView();
        }
    }
}
