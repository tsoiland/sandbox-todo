namespace Sandbox.Todo.Presentation.Cli.ViewModels
{
    public class TodoViewModel
    {
        public TodoViewModel(int lineNumber, string text)
        {
            this.LineNumber = lineNumber.ToString();
            this.Text = text;
        }

        public string LineNumber { get; set; }
        public string Text { get; set; }
    }
}