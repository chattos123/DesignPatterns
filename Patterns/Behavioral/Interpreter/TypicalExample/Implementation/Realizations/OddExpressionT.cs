//------------------------------------------------------------------------------
// <file>OddExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the OddExpressionT class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that performs modulo (%) operation
//   between two sub-expressions.
// </summary>
//------------------------------------------------------------------------------

using System;
using Patterns.Behavioral.Interpreter.TypicalExample.Interface;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a modulo operation in the Interpreter pattern.
    /// Evaluates the left-hand side and right-hand side expressions and returns
    /// the remainder of their division.
    /// </summary>
    internal class OddExpressionT : IExpressionT
    {
        private readonly IExpressionT _left;
        private readonly IExpressionT _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OddExpressionT"/> class.
        /// </summary>
        /// <param name="left">Input: Left-hand side expression.</param>
        /// <param name="right">Input: Right-hand side expression.</param>
        /// <remarks>
        /// Both parameters must implement <see cref="IExpressionT"/> and cannot be null.
        /// </remarks>
        public OddExpressionT(IExpressionT left, IExpressionT right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            _right = right ?? throw new ArgumentNullException(nameof(right), "Right expression cannot be null.");
        }

        /// <summary>
        /// Interprets the modulo expression.
        /// </summary>
        /// <returns>Output: The remainder of left ÷ right as a double.</returns>
        /// <remarks>
        /// Throws <see cref="DivideByZeroException"/> if the right-hand side evaluates to zero.
        /// This method recursively evaluates both sub-expressions and applies the modulo operator.
        /// </remarks>
        public double Interpret()
        {
            double denominator = _right.Interpret();

            if (denominator == 0)
            {
                throw new DivideByZeroException("BODMAS violation: Modulo by zero encountered.");
            }

            return _left.Interpret() % denominator;
        }
    }
}
