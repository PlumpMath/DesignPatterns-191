using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Codes.Interpreter
{
    public class Parser : IParser
   {
     public IExpression Parse(string polishNotation)
     {
       List<string> symbols = polishNotation.Split(' ').ToList();
       return ParseNextExpression(symbols);
     }
 
     private IExpression ParseNextExpression(List<string> symbols)
     {
       int value;
       if (int.TryParse(symbols[0], out value))
       {
         symbols.RemoveAt(0);
         return new IntTerminalExpression(value);
       }

       return ParseNonTerminalExpression(symbols);
     }
 
     private IExpression ParseNonTerminalExpression(List<string> symbols)
     {
       string symbol = symbols[0];
       symbols.RemoveAt(0);
 
       var exp1 = ParseNextExpression(symbols);
       var exp2 = ParseNextExpression(symbols);
 
       switch (symbol)
       {
         case "+":
           return new AddNonterminalExpression(exp1, exp2);
         case "-":
           return new SubNonterminalExpression(exp1, exp2);
         default:
           {
             string message = string.Format("Invalid Symbol ({0})", symbol);
             throw new InvalidOperationException(message);
           }
       }
     }
   }
}
