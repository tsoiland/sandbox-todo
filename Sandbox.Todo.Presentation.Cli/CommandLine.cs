namespace Sandbox.Todo.Presentation.Cli
{
    using System;

    /// <summary>
    /// The responsibility of this class is to operate the Console by 
    ///     reading input,
    ///     passing the input to the interpreter and
    ///     writing to the Console the interpreter response.
    /// </summary>
    public class CommandLine
    {
        private readonly Interpreter interpreter;

        public CommandLine(Interpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Start()
        {
            string output;
            do
            {
                // Input
                var input = Console.ReadLine();

                // Interpret
                output = this.interpreter.Interpret(input);

                // Output
                if (output != null)
                {
                    Console.WriteLine(output);
                }
            }
            while (output != null);
        }
    }
}