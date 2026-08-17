//------------------------------------------------------------------------------
// <file>AddExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the AddExpressionT class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that performs addition between two sub-expressions.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.TypicalExample.Interface;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations
{
    /// <summary>
    /// Represents an addition operation in the Interpreter pattern.
    /// Evaluates the left-hand side and right-hand side expressions and returns their sum.
    /// </summary>
    internal class AddExpressionT : IExpressionT
    {
        private readonly IExpressionT _left;
        private readonly IExpressionT _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddExpressionT"/> class.
        /// </summary>
        /// <param name="left">Input: Left-hand side expression.</param>
        /// <param name="right">Input: Right-hand side expression.</param>
        /// <remarks>
        /// Both parameters must implement <see cref="IExpressionT"/> and cannot be null.
        /// </remarks>
        public AddExpressionT(IExpressionT left, IExpressionT right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            _right = right ?? throw new ArgumentNullException(nameof(right), "Right expression cannot be null.");
        }

        /// <summary>
        /// Interprets the addition expression.
        /// </summary>
        /// <returns>Output: The sum of the evaluated left and right expressions as a double.</returns>
        /// <remarks>
        /// This method recursively evaluates both sub-expressions and combines their results.
        /// </remarks>
        public double Interpret() => _left.Interpret() + _right.Interpret();
    }
}