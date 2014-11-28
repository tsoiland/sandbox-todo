namespace Sandbox.Todo.Presentation.Cli
{
    using System.Collections.Generic;
    using Sandbox.Todo.Presentation.Cli.Controllers;

    // An action is a method that takes a list of string arguments and returns a view.
    using Action = System.Func<System.Collections.Generic.IList<string>,Views.IView>;

    /// <summary>
    /// The responsibility of this class is to know which commands map to which action methods.
    /// The command will be given to us in the form of a string, and we're supposed to return
    /// an actual method that can be invoked.
    /// 
    /// P.S. 
    /// Check out the alias for "Action" above. It's purely syntactic sugar. The route field
    /// looked like a mess otherwise.
    /// </summary>
    public class Route
    {
        private readonly IDictionary<string, Action> route;

        public Route(Controller controller)
        {
            this.route = new Dictionary<string, Action>
                    {
                        { "a", controller.Add },
                        { "l", controller.List },
                        { "p", controller.SetPriority },
                        { "r", controller.Remove },
                    };
        }

        public Action LookupAction(string actionName)
        {
            return this.route[actionName];
        }

        public bool ContainsAction(string actionName)
        {
            return this.route.ContainsKey(actionName);
        }
    }
}
