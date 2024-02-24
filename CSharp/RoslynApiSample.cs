using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace CodeAnalysisApp
{
    internal class Program
    {
        private static string _dmyCode =
                                    @"namespace DummyNamespace
                                    {
                                        internal class Dummy
                                        {
                                            public string DummyStringProp { get;} 
                                            public int DummyIntProp { get;} 
                                            /// <summary>
                                            /// フィールド
                                            /// </summary>
                                            public string DummyField = ""フィールドです"";
                                        }
                                    }";
        static void Main(string[] args)
        {
            //var target = Util.GetTargetFileInfo();
            //if (!target.Exists) return;

            var tree = CSharpSyntaxTree.ParseText(_dmyCode);
            var root = tree.GetCompilationUnitRoot();

            var nodes = root.DescendantNodes();

            // プロパティを取得
            var props = nodes.OfType<PropertyDeclarationSyntax>()
                             .ToList();
            props.ForEach(p => Debug.WriteLine(p.ToFullString()));

            // フィールドを取得
            var field = nodes.OfType<FieldDeclarationSyntax>()
                             .ToList();
            field.ForEach(f => Debug.WriteLine(f.ToFullString()));
        }
    }

    internal static class Util
    {
        public static FileInfo GetTargetFileInfo()
        {
            using var f = new OpenFileDialog
            {
                Filter = "|*.cs",
            };

            var dialogResult = f.ShowDialog();
            if (dialogResult != DialogResult.OK) return new FileInfo("");

            return new FileInfo(f.FileName);
        }
    }
}