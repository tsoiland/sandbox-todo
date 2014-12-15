namespace Sandbox.Todo.CompositionRoot.Web
{
    using System;

    using Sandbox.Todo.Application;
    using Sandbox.Todo.Persistence.InMemory;
    using Sandbox.Todo.Presentation.Web.Controllers;
    using Sandbox.Todo.Presentation.Web.Plumbing;

    public class MainClass
    {
        public static void Main()
        {
            var route = new Route(new Controller(new TodoService(new InMemoryTodoRepository())));
            var route2 = new ContentRoute();

            const int portNumber = 1235;
            Console.WriteLine("Running on http://localhost:{0}", portNumber);

            new WebServer(new DataParser(), new OuterRouter(route, route2)).Run(portNumber);
        }
    }
}