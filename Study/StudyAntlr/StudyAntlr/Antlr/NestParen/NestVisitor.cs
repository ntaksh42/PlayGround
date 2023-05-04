using Antlr4.Runtime.Tree;
using System.Diagnostics.CodeAnalysis;

namespace StudyAntlr.Antlr.nestParen
{
    public class NestVisitor : nestParenBaseVisitor<object>
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

        public override object VisitExpr([NotNull] nestParenParser.ExprContext context)
        {
            return base.VisitExpr(context);
        }
    }
}