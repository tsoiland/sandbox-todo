namespace Sandbox.Todo.CompositionRoot
{
    using Sandbox.Todo.Application;
    using Sandbox.Todo.Persistence.InMemory;
    using Sandbox.Todo.Presentation.Cli;
    using Sandbox.Todo.Presentation.Cli.Controllers;

    /// <summary>
    /// This is the systems entry point. It is responsible for composition of the entire system
    /// and for starting the user interface.
    /// </summary>
    public class Start
    {
        public static void Main()
        {
            // Resolve dependencies
            var secondaryStorage = new SecondaryStorage(new Serializer());
            var unitOfWork = new UnitOfWork(secondaryStorage);
            var todoService = new TodoServiceAtomic(new TodoService(new AtomicTodoRepository(unitOfWork, secondaryStorage)), unitOfWork);

            var commandLine = 
                new CommandLine(
                    new Interpreter(
                        new Route(
                            new Controller(
                                todoService))));

            // Start command line
            commandLine.Start();
        }
    }
}
