namespace DesignPatterns.Codes.Interpreter
{
    public interface IParser
    {
        IExpression Parse(string polishNotation);
    }
}
