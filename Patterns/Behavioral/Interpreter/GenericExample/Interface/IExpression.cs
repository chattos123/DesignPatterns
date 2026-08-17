//------------------------------------------------------------------------------
// <file>IExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the IExpression interface for the Interpreter Design Pattern.
//   Provides a contract for all expression classes to implement the Interpret method.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Interface
{
    /// <summary>
    /// Interface for all expression types in the Interpreter pattern.
    /// Each expression must implement the Interpret method to evaluate itself
    /// within the given context.
    /// </summary>
    internal interface IExpression
    {
        /// <summary>
        /// Interprets the expression using the provided context.
        /// </summary>
        /// <param name="context">Input: Context object containing variable mappings.</param>
        /// <returns>Output: Evaluated integer result of the expression.</returns>
        /// <remarks>
        /// Terminal expressions may ignore the context, while non-terminal
        /// expressions typically use it to store or retrieve variable values.
        /// </remarks>
        int Interpret(Context context);
    }
}