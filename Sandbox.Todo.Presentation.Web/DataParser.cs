namespace Sandbox.Todo.Presentation.Web
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class DataParser
    {
        public NameValueCollection ActionParameterGatherer(HttpListenerRequest request)
        {
            // Add query string values
            var actionParameters = request.QueryString;

            // Add post parameters
            if (request.HttpMethod == "POST")
            {
                var postValues = this.ParsePostValues(request);
                foreach (var pair in postValues)
                {
                    actionParameters.Add(pair.Key, pair.Value);
                }
            }

            return actionParameters;
        }

        private Dictionary<string, string> ParsePostValues(HttpListenerRequest request)
        {
            // Read the string of post data from the request
            var text = this.ReadPostString(request);
            
            return text
                .Split('&')                             // Break the pairs appart
                .Select(aa => aa.Split('='))            // Break the key and value apart
                .ToDictionary(a => a[0], a => a[1]);    // Project to dictionary
        }

        private string ReadPostString(HttpListenerRequest request)
        {
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
}