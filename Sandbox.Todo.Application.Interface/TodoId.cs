namespace Sandbox.Todo.Application.Interface
{
    using System;

    [Serializable]
    public class TodoId : Id
    {
        public TodoId(Guid guid) : base(guid)
        {}

        public TodoId(string guid) : base(guid)
        {}

        public TodoId()
        {}
    }
}