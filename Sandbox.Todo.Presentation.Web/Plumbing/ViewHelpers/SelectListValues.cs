namespace Sandbox.Todo.Presentation.Web.Plumbing.ViewHelpers
{
    using System.Collections.Generic;
    using System.Linq;

    public class SelectListValues
    {
        public static SelectListValues New<T>(string name, IEnumerable<T> options)
        {
            return new SelectListValues { Name = name, Options = options.Select(o => new SelectListOption { Value = o.ToString(), Text = o.ToString() }) };
        }

        public string Name { get; set; }
        public IEnumerable<SelectListOption> Options { get; set; }
    }
}