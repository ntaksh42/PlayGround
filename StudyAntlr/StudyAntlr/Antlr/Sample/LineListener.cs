
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace StudyAntlr
{
    public partial class Program
    {
        public class LineListener : sampleBaseListener 
        {
            public override void EnterEveryRule([NotNull] ParserRuleContext context)
            {
                base.EnterEveryRule(context);
                var temp = context.GetText();
            }
            public override void EnterLine([NotNull] sampleParser.LineContext context)
            {
                base.EnterLine(context);
                var temp = context.COMMENT();
                var temp2 = context.WS();
                var temp3 = context.body();

            }
        }
    }
}