
using Antlr4.Runtime;
using StudyAntlr.Antlr.nestParen;

namespace StudyAntlr
{
    public partial class Program
    {
        public static class NestParenManager
        {
            public static void CountNestDeps(string str)
            {
                var input = new AntlrInputStream(str);
                var lexer = new nestParenLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                nestParenParser parser = new nestParenParser(tokens);

                var expr = parser.expr();
                foreach (var ele in expr.children)
                {
                    var visitor = new NestVisitor();
                    visitor.Visit(ele);
                    Console.WriteLine($"{ele.GetText()}:{visitor.NestDepsMax}");
                }
            }
        }

        
    }
}