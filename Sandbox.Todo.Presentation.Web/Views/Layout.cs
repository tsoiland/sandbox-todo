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
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Todo application</title>
                    <meta http-equiv='Content-Type' content='text/html;charset=utf-8' >
                    <link rel='stylesheet' type='text/css' href='/Content/style.css' />    
                </head>
                <body>
                    <div id='container'>" +
                        this.view.Render() + @"
                    </div>
                </body>
                </html>";
        }
    }
}