namespace Sandbox.Todo.Presentation.Web.Views
{
    using Sandbox.Todo.Presentation.Web.Plumbing.ActionResults;

    public class Layout : View
    {
        private readonly View view;

        public Layout(View view)
        {
            this.view = view;
        }

        public override string Render()
        {
            return @"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Todo application</title>
                    <meta http-equiv='Content-Type' content='text/html;charset=utf-8' />
                    <link rel='stylesheet' type='text/css' href='/content/style.css' />  
                    <script type='text/javascript' src='/content/script.js'></script>                    
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