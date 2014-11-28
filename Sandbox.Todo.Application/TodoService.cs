namespace Sandbox.Todo.Application
{
    using System.Collections.Generic;
    using System.Linq;

    using Sandbox.Todo.Application.Interface;

    /// <summary>
    /// See comments on interface ITodoService.
    /// </summary>
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public TodoId Add(string text)
        {
            var todo = new Todo();
            todo.Text = text;
            this.todoRepository.Add(todo);

            return todo.Id;
        }

        public IList<TodoDto> GetAll()
        {
            return this.todoRepository.GetAll()
                .OrderByDescending(t => t.Priority)
                .Select(t => new TodoDto
                    {
                        Id = t.Id,
                        Text = t.Text
                    })
                .ToList();
        }

        public void Remove(TodoId id)
        {
            var todo = this.todoRepository.Get(id);
            this.todoRepository.Remove(todo);
        }

        public void SetPriority(TodoId todoId, int priority)
        {
            var todo = this.todoRepository.Get(todoId);
            todo.Priority = priority;
        }
    }
}