//------------------------------------------------------------------------------
// <file>MultiplyExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the MultiplyExpressionT class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that performs multiplication between two sub-expressions.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.TypicalExample.Interface;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a multiplication operation in the Interpreter pattern.
    /// Evaluates the left-hand side and right-hand side expressions and returns their product.
    /// </summary>
    internal class MultiplyExpressionT : IExpressionT
    {
        private readonly IExpressionT _left;
        private readonly IExpressionT _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplyExpressionT"/> class.
        /// </summary>
        /// <param name="left">Input: Left-hand side expression.</param>
        /// <param name="right">Input: Right-hand side expression.</param>
        /// <remarks>
        /// Both parameters must implement <see cref="IExpressionT"/> and cannot be null.
        /// </remarks>
        public MultiplyExpressionT(IExpressionT left, IExpressionT right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            _right = right ?? throw new ArgumentNullException(nameof(right), "Right expression cannot be null.");
        }

        /// <summary>
        /// Interprets the multiplication expression.
        /// </summary>
        /// <returns>Output: The product of the evaluated left and right expressions as a double.</returns>
        /// <remarks>
        /// This method recursively evaluates both sub-expressions and multiplies their results.
        /// </remarks>
        public double Interpret() => _left.Interpret() * _right.Interpret();
    }
}