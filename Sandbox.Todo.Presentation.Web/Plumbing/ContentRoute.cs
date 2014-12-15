namespace Sandbox.Todo.Presentation.Web.Plumbing
{
    using System.Collections.Specialized;
    using System.IO;

    public class ContentRoute
    {
        public bool HasMatch(string actionName)
        {
            return true;
        }

        public string Invoke(string rawUrl, NameValueCollection arg)
        {
            var url = rawUrl.TrimStart('/');
            using (var sr = new StreamReader(url))
            {
                return sr.ReadToEnd();
            }
        }
    }
}