namespace Sandbox.Todo.Persistence.InMemory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnitOfWork
    {
        private readonly List<KeyValuePair<Guid, object>> pendingSaveEntries;
        private readonly SecondaryStorage secondaryStorage;
        private readonly IList<Guid> pendingRemovalEntries;

        public UnitOfWork(SecondaryStorage secondaryStorage)
        {
            this.secondaryStorage = secondaryStorage;
            this.pendingRemovalEntries = new List<Guid>();
            this.pendingSaveEntries = new List<KeyValuePair<Guid, object>>();
        }

        public void Add(Guid id, object o)
        {
            this.pendingSaveEntries.Add(new KeyValuePair<Guid, object>(id, o));
        }

        public void Remove(Guid id)
        {
            // Mark for removal.
            this.pendingRemovalEntries.Add(id);

            // Make sure it's not re-added by a pending save.
            this.pendingSaveEntries
                .Where(e => e.Key == id)
                .Select(e => this.pendingSaveEntries.Remove(e));
        }

        public void Commit()
        {
            foreach (var entry in this.pendingSaveEntries)
            {
                this.secondaryStorage.Write(entry.Key, entry.Value);
            }

            foreach (var id in this.pendingRemovalEntries)
            {
                this.secondaryStorage.Remove(id);
            }
        }
    }
}