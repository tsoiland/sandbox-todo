namespace Sandbox.Todo.Presentation.Web
{
    using Sandbox.Todo.Application;
    using Sandbox.Todo.Persistence.InMemory;
    using Sandbox.Todo.Presentation.Web.Content;
    using Sandbox.Todo.Presentation.Web.Controllers;

    public class MainClass
    {
        public static void Main()
        {
            var route = new ControllerRoute(new Controller(new TodoService(new InMemoryTodoRepository())));
            var route2 = new ContentRoute();

            new WebServer(new DataParser(), new OuterRouter(route, route2)).Run(1235);
        }
    }
}