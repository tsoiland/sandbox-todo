namespace Sandbox.Todo.CompositionRoot.Web
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

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
                .ToDictionary(                          // Project to dictionary
                    c => this.UrlDecode(c[0]), 
                    c => this.UrlDecode(c[1]));    
        }

        private string UrlDecode(string text)
        {
            var replaced = text
                .Replace('+', ' ')
                .Replace("%25", "%");

            var a = "!	#	$	&	'	(	)	*	+	,	/	:	;	=	?	@	[	]".Split('\t');
            var b = "%21 %23 %24 %26 %27 %28 %29 %2A %2B %2C %2F %3A %3B %3D %3F %40 %5B %5D".Split(' ');

            var i = 0;
            foreach (var s in a)
            {
                replaced = replaced.Replace(b[i], a[i++]);
            }
            return replaced;
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