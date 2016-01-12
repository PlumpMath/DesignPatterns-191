namespace DesignPatterns.Codes.Interpreter
{
    public interface IExpression
    {
        /// <summary>
        /// 计算求值
        /// </summary>
        /// <returns></returns>
        int Evaluate();
    }
}
