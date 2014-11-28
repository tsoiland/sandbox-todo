namespace Sandbox.Todo.Persistence.InMemory
{
    using System.Collections.Generic;
    using System.Linq;

    using Sandbox.Todo.Application;
    using Sandbox.Todo.Application.Interface;

    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly IList<Todo> todos;

        public InMemoryTodoRepository()
        {
            this.todos = new List<Todo>();
        }

        public void Add(Todo todo)
        {
            this.todos.Add(todo);
        }

        public Todo Get(TodoId id)
        {
            return this.todos.Single(t => t.Id == id);
        }

        public void Remove(Todo todo)
        {
            this.todos.Remove(todo);
        }

        public IList<Todo> GetAll()
        {
            return this.todos.ToList();
        }
    }
}