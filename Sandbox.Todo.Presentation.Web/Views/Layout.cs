namespace Sandbox.Todo.Presentation.Web.Views
{
    public class Layout : IView
    {
        private readonly IView view;

        public Layout(IView view)
        {
            this.view = view;
        }

        public string Render()
        {
            return @"
                <html>
                <head>
                    <title>Todo application</title>
                    <link rel='stylesheet' type='text/css' href='/Content/style.css' />
                </head>
                <body>" +
                   this.view.Render() + @"
                </body>
                </html>";
        }
    }
}