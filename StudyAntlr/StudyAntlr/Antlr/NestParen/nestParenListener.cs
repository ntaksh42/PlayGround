//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from nestParen.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="nestParenParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface InestParenListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="nestParenParser.prenBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrenBlock([NotNull] nestParenParser.PrenBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="nestParenParser.prenBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrenBlock([NotNull] nestParenParser.PrenBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="nestParenParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] nestParenParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="nestParenParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] nestParenParser.ExprContext context);
}