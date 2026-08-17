//------------------------------------------------------------------------------
// <file>SubtractExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the SubtractExpression class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that performs subtraction between two sub-expressions.
// </summary>
//------------------------------------------------------------------------------

using System;
using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a subtraction operation in the Interpreter pattern.
    /// Evaluates the left-hand side expression and subtracts the result of the right-hand side expression.
    /// </summary>
    internal class SubtractExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractExpression"/> class.
        /// </summary>
        /// <param name="left">Input: Left-hand side expression.</param>
        /// <param name="right">Input: Right-hand side expression.</param>
        /// <remarks>
        /// Both parameters must implement <see cref="IExpression"/> and cannot be null.
        /// </remarks>
        public SubtractExpression(IExpression left, IExpression right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            _right = right ?? throw new ArgumentNullException(nameof(right), "Right expression cannot be null.");
        }

        /// <summary>
        /// Interprets the subtraction expression using the provided context.
        /// </summary>
        /// <param name="context">Input: Context object containing variable mappings.</param>
        /// <returns>Output: Integer result of evaluating left - right.</returns>
        /// <remarks>
        /// Throws <see cref="ArgumentNullException"/> if the context is null.
        /// </remarks>
        public int Interpret(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context cannot be null.");
            }

            return _left.Interpret(context) - _right.Interpret(context);
        }
    }
}