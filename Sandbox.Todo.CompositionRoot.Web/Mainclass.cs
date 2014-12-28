namespace Sandbox.Todo.CompositionRoot.Web
{
    using System;
    using System.Collections.Generic;

    using Sandbox.Todo.Application;
    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Persistence.Atomic;
    using Sandbox.Todo.Persistence.InMemory;
    using Sandbox.Todo.Presentation.Web.Controllers;
    using Sandbox.Todo.Presentation.Web.Plumbing;

    public class MainClass
    {
        public static void Main()
        {
            ////var todoService = new TodoService(new InMemoryTodoRepository());
            
            var secondaryStorage = new SecondaryStorage(new Serializer());
            var unitOfWork = new UnitOfWork(secondaryStorage);
            var todoService = new TodoServiceIntercept(new TodoService(new AtomicTodoRepository(unitOfWork, secondaryStorage)), unitOfWork);

            var route = new Route(new Controller(todoService));

            const int portNumber = 1235;
            Console.WriteLine("Running on http://localhost:{0}", portNumber);

            new WebServer(new DataParser(), route).Run(portNumber);
        }
    }

    public class TodoServiceIntercept : ITodoService
    {
        private readonly TodoService todoService;
        private readonly UnitOfWork unitOfWork;

        public TodoServiceIntercept(TodoService todoService, UnitOfWork unitOfWork)
        {
            this.todoService = todoService;
            this.unitOfWork = unitOfWork;
        }

        public TodoId Add(string text)
        {
            var todoId = this.todoService.Add(text);
            this.unitOfWork.Commit();
            return todoId;
        }

        public IList<TodoDto> GetAll()
        {
            return this.todoService.GetAll();
        }

        public void Remove(TodoId id)
        {
            this.todoService.Remove(id);
            this.unitOfWork.Commit();
        }

        public void SetPriority(TodoId todoId, int priority)
        {
            this.todoService.SetPriority(todoId, priority);
            this.unitOfWork.Commit();
        }
    }
}