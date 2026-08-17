//------------------------------------------------------------------------------
// <file>IExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the IExpressionT interface for the Interpreter Design Pattern.
//   Provides a contract for all mathematical expression classes to implement
//   the Interpret method, which evaluates the expression and returns a result.
// </summary>
//------------------------------------------------------------------------------

namespace Patterns.Behavioral.Interpreter.TypicalExample.Interface
{
    /// <summary>
    /// Interface for all expression types in the typical math parser example.
    /// Each expression must implement the Interpret method to evaluate itself
    /// and return a numeric result.
    /// </summary>
    internal interface IExpressionT
    {
        /// <summary>
        /// Interprets the expression and evaluates its numeric result.
        /// </summary>
        /// <returns>Output: The evaluated result of the expression as a double.</returns>
        /// <remarks>
        /// Terminal expressions (like numbers) return their literal value.
        /// Non-terminal expressions (like addition, subtraction, multiplication)
        /// recursively evaluate their sub-expressions and combine results.
        /// </remarks>
        double Interpret();
    }
}