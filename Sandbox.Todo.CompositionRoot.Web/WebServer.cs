namespace Sandbox.Todo.CompositionRoot.Web
{
    using System.Net;
    using System.Text;

    using Sandbox.Todo.Presentation.Web.Plumbing;

    public class WebServer
    {
        private readonly DataParser dataParser;
        private readonly Route route;

        public WebServer(DataParser dataParser, Route route)
        {
            this.dataParser = dataParser;
            this.route = route;
        }

        public void Run(int portNumber)
        {
            // Set up webserver
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://*:" + portNumber + "/");
            httpListener.Start();

            // Process requests
            while (true)
            {
                // Listen for http requests
                var context = httpListener.GetContext();
                var request = context.Request;

                // Ignore some bullshit I don't want to look up.
                if (request.RawUrl == "/favicon.ico")
                {
                    continue;
                }

                // Invoke handler
                var getAndPostParameters = this.dataParser.ActionParameterGatherer(request);
                var result = this.route.Invoke(request.RawUrl, getAndPostParameters, context.Response.Redirect);

                // Send http response
                var byteData = Encoding.Default.GetBytes((string)result);
                context.Response.OutputStream.Write(byteData, 0, byteData.Length);
                context.Response.OutputStream.Close();
            }
        }
    }
}
