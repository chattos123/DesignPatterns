//------------------------------------------------------------------------------
// <file>AddExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the AddExpression class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that performs addition of two sub-expressions.
// </summary>
//------------------------------------------------------------------------------

using System;
using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations
{
    /// <summary>
    /// Represents an addition operation in the Interpreter pattern.
    /// Combines two sub-expressions and evaluates their sum.
    /// </summary>
    internal class AddExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddExpression"/> class.
        /// </summary>
        /// <param name="left">Input: Left-hand side expression.</param>
        /// <param name="right">Input: Right-hand side expression.</param>
        /// <remarks>
        /// Both sub-expressions must implement <see cref="IExpression"/>.
        /// </remarks>
        public AddExpression(IExpression left, IExpression right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left), "Left expression cannot be null.");
            _right = right ?? throw new ArgumentNullException(nameof(right), "Right expression cannot be null.");
        }

        /// <summary>
        /// Interprets the addition expression using the provided context.
        /// </summary>
        /// <param name="context">Input: Context object containing variable mappings.</param>
        /// <returns>Output: Integer result of evaluating left + right.</returns>
        /// <remarks>
        /// Throws <see cref="ArgumentNullException"/> if the context is null.
        /// </remarks>
        public int Interpret(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context cannot be null.");
            }

            return _left.Interpret(context) + _right.Interpret(context);
        }
    }
}