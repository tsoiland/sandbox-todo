﻿namespace Sandbox.Todo.Application.Interface
{
    using System;

    public class TodoId : Id
    {
        public TodoId(Guid guid) : base(guid)
        {}

        public TodoId()
        {}
    }
}