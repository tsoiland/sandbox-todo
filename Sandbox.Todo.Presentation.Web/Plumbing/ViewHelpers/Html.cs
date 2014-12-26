namespace Sandbox.Todo.Presentation.Web.Plumbing.ViewHelpers
{
    using System.Text;

    public class Html
    {
        public static string SelectList(SelectListValues selectListValueses)
        {
            var output = new StringBuilder();

            output.AppendFormat("<select name='{0}'>", selectListValueses.Name);

            foreach(var option in selectListValueses.Options)
            {
                output.AppendFormat("<option value='{0}'>{1}</option>", option.Value, option.Text);
            }

            output.AppendLine("</select>");

            return output.ToString();
        }
    }
}