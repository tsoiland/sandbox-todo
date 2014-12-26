namespace Sandbox.Todo.Application.Interface
{
    using System;

    public abstract class Id
    {
        private readonly Guid guid;

        protected Id(string guid)
        {
            this.guid = new Guid(guid);
        }

        protected Id(Guid guid)
        {
            this.guid = guid;
        }

        protected Id()
        {
            this.guid = Guid.NewGuid();
        }

        public Guid Guid
        {
            get
            {
                return this.guid;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Id;
            if (other == null) return false;

            return other.guid == this.guid;
        }

        protected bool Equals(Id other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return this.guid.GetHashCode();
        }

        public static bool operator ==(Id id1, Id id2)
        {
            if (ReferenceEquals(id1, null))
            {
                return ReferenceEquals(id2, null);
            }

            if (ReferenceEquals(id2, null))
            {
                return false;
            }

            return id1.guid == id2.guid;
        }

        public static bool operator !=(Id id1, Id id2)
        {
            return !(id1 == id2);
        }

        public override string ToString()
        {
            return this.guid.ToString();
        }
    }
}