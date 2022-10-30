using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Diagnostics.CodeAnalysis;

using static System.Environment;

namespace StudyAntlr
{

    public partial class Program
    {
        public static void Main(string[] args)
        {
            var sourceFileFullPath = Path.Combine(CurrentDirectory, "temp.txt");
            var stSource = File.ReadAllText(sourceFileFullPath);
            var input = new AntlrInputStream(stSource);
            var lexer = new stParserLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            var parser = new stParserParser(tokens);
            var expr = parser.expr();

            Console.WriteLine();
            foreach(var ele in expr.children)
            {
                var visitor = new stVisitor();
                visitor.Visit(ele);
                Console.WriteLine($"IF NestDepth --->{visitor.NestDepsMax}");
                Console.WriteLine("------------------");
                Console.WriteLine($"{ele.GetText()}");
                Console.WriteLine("------------------");
            }
        }

        public class stVisitor : stParserBaseVisitor<object>
        {
            public int NestDepsMax { get; private set; }
            public override object Visit([NotNull] IParseTree tree)
            {
                return base.Visit(tree);
            }

            public override object VisitChildren([NotNull] IRuleNode node)
            {
                var depth = node.RuleContext.Depth() - 1;
                if (NestDepsMax < depth) NestDepsMax = depth;
                return base.VisitChildren(node);
            }

            public override object VisitTerminal([NotNull] ITerminalNode node)
            {
                return base.VisitTerminal(node);
            }

            public override object VisitExpr([NotNull] stParserParser.ExprContext context)
            {
                return base.VisitExpr(context);
            }
        }
    }
}