namespace Sandbox.Todo.Application
{
    using Sandbox.Todo.Application.Interface;

    /// <summary>
    /// Todos represents a commitments of some person to perform some action. 
    /// 
    /// Some purposes of tracking these todos are:
    ///   - Not forgetting to perform them.
    ///   - Relieving the human brain of this tracking responsibility, 
    ///     thereby lowering stress and enableing creative activity.
    ///   - The human brain is better at deciding on priorities when presented
    ///     with all items in the same list, and allowed to move them around
    ///     into priority order.
    /// 
    /// The action is usually tracked by a short textual reminder.
    /// </summary>
    public class Todo
    {
        public Todo()
        {
            this.Id = new TodoId();
        }

        public TodoId Id { get; private set; }
        public string Text { get; set; }
        public int Priority { get; set; }
    }
}