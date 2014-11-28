namespace Sandbox.Todo.Application
{
    using System.Collections.Generic;

    using Sandbox.Todo.Application.Interface;

    public interface ITodoRepository
    {
        void Add(Todo todo);
        Todo Get(TodoId id); 
        void Remove(Todo todo);
        IList<Todo> GetAll();
    }
}