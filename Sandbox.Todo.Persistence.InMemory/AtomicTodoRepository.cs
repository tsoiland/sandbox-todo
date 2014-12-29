namespace Sandbox.Todo.Persistence.InMemory
{
    using System.Collections.Generic;
    using System.Linq;

    using Sandbox.Todo.Application;
    using Sandbox.Todo.Application.Interface;

    public class AtomicTodoRepository : ITodoRepository
    {
        private readonly UnitOfWork unitOfWork;
        private readonly SecondaryStorage secondaryStorage;

        public AtomicTodoRepository(UnitOfWork unitOfWork, SecondaryStorage secondaryStorage)
        {
            this.unitOfWork = unitOfWork;
            this.secondaryStorage = secondaryStorage;
        }

        public void Add(Todo todo)
        {
            this.unitOfWork.Add(todo.Id.Guid, todo);
        }

        public void Remove(Todo todo)
        {
            this.unitOfWork.Remove(todo.Id.Guid);
        }

        public IList<Todo> GetAll()
        {
            return this.secondaryStorage.ReadAll().Cast<Todo>().ToList();
        }

        public Todo Get(TodoId id)
        {
            return (Todo)this.secondaryStorage.Read(id.Guid);
        }
    }
}