namespace DesignPatterns.Codes.Interpreter
{
    public class AddNonterminalExpression : IExpression
    {
        private IExpression _exp1;
        private IExpression _exp2;

        public AddNonterminalExpression(IExpression exp1, IExpression exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }

        /// <summary>
        /// 求和并返回和值
        /// </summary>
        /// <returns></returns>
        public int Evaluate()
        {
            return _exp1.Evaluate() + _exp2.Evaluate();
        }

        public override string ToString()
        {
            return string.Format("({0} + {1})", _exp1, _exp2);
        }

    }
}
