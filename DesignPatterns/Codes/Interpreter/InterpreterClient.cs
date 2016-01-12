using System;

namespace DesignPatterns.Codes.Interpreter
{
    public class InterpreterClient
    {
        public void TestCase()
        {
            IParser parser = new Parser();

            var commands =
              new string[]
              {
                   "+ 1 2",
                   "- 3 4",
                   "+ - 5 6 7",
                   "+ 8 - 9 1",
                   "+ - + - - 2 3 4 + - -5 6 + -7 8 9 0"
              };

            foreach (var command in commands)
            {
                IExpression expression = parser.Parse(command);
                Console.WriteLine("{0} = {1}", expression, expression.Evaluate());
            }

            // Results:
            // (1 + 2) = 3
            // (3 - 4) = -1
            // ((5 - 6) + 7) = 6
            // (8 + (9 - 1)) = 16
            // (((((2 - 3) - 4) + ((-5 - 6) + (-7 + 8))) - 9) + 0) = -24

        }
    }
}