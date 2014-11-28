namespace Sandbox.Todo.Presentation.Cli
{
    using System.Linq;

    /// <summary>
    /// The responsibility of this class is to parse commands and make them happen.
    /// It makes things happen by invoking actions.
    /// It knows which action to invoke by looking up the string command in a route.
    /// 
    /// An action returns a view, which can be rendered to a string.
    /// That string is the respons to the command.
    /// </summary>
    public class Interpreter
    {
        private readonly Route route;

        public Interpreter(Route route)
        {
            this.route = route;
        }

        public string Interpret(string input)
        {
            // Look for exit cues
            if (input == "exit" || input == "q") 
                return null;

            // Parse args
            var splitInput = input.Split(' ');
            var actionName = splitInput.First();
            var args = splitInput.Skip(1).ToList();

            // Check if action exists
            if (!this.route.ContainsAction(actionName))
            {
                return "Unknown command";
            }
            
            // Invoke
            var view = this.route.LookupAction(actionName).Invoke(args);

            // Render
            return view.Render();
        }
    }
}