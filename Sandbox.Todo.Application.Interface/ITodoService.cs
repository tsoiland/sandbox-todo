namespace Sandbox.Todo.Application.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// The responsibility of this interface is to define the public operations of 
    /// the application, thereby acting as an application boundary.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Start tracking a new commitment
        /// </summary>
        /// <param name="text">A textual reminder of the action to perform.</param>
        /// <returns>A unique identifier of the newly tracked commitment.</returns>
        TodoId Add(string text);

        /// <summary>
        /// Get a complete list of currently tracked commitments.
        /// The commitments are sorted by descending priority value.
        /// </summary>
        /// <returns>A list of commitments.</returns>
        IList<TodoDto> GetAll();

        /// <summary>
        /// Stop tracking a commitment that is currently being tracked.
        /// </summary>
        /// <param name="id">The unique identifier for the commitment, as presented by GetAll()</param>
        void Remove(TodoId id);

        /// <summary>
        /// Set a numbered priority for a commitment being tracked.
        /// </summary>
        /// <param name="todoId">he unique identifier for the commitment, as presented by GetAll()</param>
        /// <param name="priority">A numeric priority. Higher number gives higher priority.</param>
        void SetPriority(TodoId todoId, int priority);
    }
}