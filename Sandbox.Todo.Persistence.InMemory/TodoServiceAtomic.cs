namespace Sandbox.Todo.Persistence.InMemory
{
    using System.Collections.Generic;

    using Sandbox.Todo.Application;
    using Sandbox.Todo.Application.Interface;

    public class TodoServiceAtomic : ITodoService
    {
        private readonly TodoService todoService;
        private readonly UnitOfWork unitOfWork;

        public TodoServiceAtomic(TodoService todoService, UnitOfWork unitOfWork)
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