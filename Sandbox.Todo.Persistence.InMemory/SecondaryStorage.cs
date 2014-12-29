namespace Sandbox.Todo.Persistence.InMemory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SecondaryStorage
    {
        private readonly IDictionary<Guid, Stream> streams;
        private readonly Serializer serializer;

        public SecondaryStorage(Serializer serializer)
        {
            this.serializer = serializer;
            this.streams = new Dictionary<Guid, Stream>();
        }

        public void Write(Guid id, object o)
        {
            var stream = this.serializer.Serialize(o);
            this.streams[id] = stream;
        }

        public object Read(Guid id)
        {
            var stream = this.streams[id];
            return this.serializer.Deserialize(stream);
        }

        public object[] ReadAll()
        {
            return this.streams.Values.Select(v => this.serializer.Deserialize(v)).ToArray();
        }

        public void Remove(Guid id)
        {
            this.streams.Remove(id);
        }
    }
}