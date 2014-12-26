namespace Sandbox.Todo.Presentation.Web.Views
{
    using Sandbox.Todo.Application.Interface;
    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;
    using Sandbox.Todo.Presentation.Web.Plumbing.ViewHelpers;

    public class SetPriorityView : View
    {
        private readonly TodoId todoId;
        private readonly SelectListValues selectListValues;

        public SetPriorityView(TodoId todoId, SelectListValues selectListValues)
        {
            this.todoId = todoId;
            this.selectListValues = selectListValues;
        }

        public override string Render()
        {
            return @"
                <h2>Set priority</h2>
                <form method='post' action='/controller/setpriority?id=" + this.todoId + @"'>" +
                    Html.SelectList(this.selectListValues) + @"
                    <button type='submit'>Save</button>
                </form>";
        }
    }
}