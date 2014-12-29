namespace Sandbox.Todo.Application
{
    using System;

    public interface IUnitOfWork
    {
        void Modified(Guid id, object o);
    }
}