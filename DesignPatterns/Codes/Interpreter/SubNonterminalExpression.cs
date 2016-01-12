namespace DesignPatterns.Codes.Interpreter
{
    public class SubNonterminalExpression : IExpression
    {
        private IExpression _exp1;
        private IExpression _exp2;

        public SubNonterminalExpression(IExpression exp1, IExpression exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }

        /// <summary>
        /// 求差，并返回结果
        /// </summary>
        /// <returns></returns>
        public int Evaluate()
        {
            return _exp1.Evaluate() - _exp2.Evaluate();
        }

        public override string ToString()
        {
            return string.Format("({0} - {1})", _exp1, _exp2);
        }
    }
}
