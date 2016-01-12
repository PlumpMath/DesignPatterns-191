namespace DesignPatterns.Codes.Interpreter
{
    public class IntTerminalExpression : IExpression
    {
        int _value;

        public IntTerminalExpression(int value)
        {
            _value = value;
        }

        public int Evaluate()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

    }
}
