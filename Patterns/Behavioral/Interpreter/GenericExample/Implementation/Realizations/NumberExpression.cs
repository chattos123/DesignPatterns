//------------------------------------------------------------------------------
// <file>NumberExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the NumberExpression class used in the Interpreter Design Pattern.
//   Represents a terminal expression that holds a numeric literal.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a numeric literal in the Interpreter pattern.
    /// This is a terminal expression that simply returns its stored value.
    /// </summary>
    internal class NumberExpression : IExpression
    {
        private readonly int _number;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberExpression"/> class.
        /// </summary>
        /// <param name="number">Input: The integer value to be stored and returned.</param>
        /// <remarks>
        /// This value is immutable once set in the constructor.
        /// </remarks>
        public NumberExpression(int number)
        {
            _number = number;
        }

        /// <summary>
        /// Interprets the number expression.
        /// </summary>
        /// <param name="context">Input: Context object (not used by this terminal expression).</param>
        /// <returns>Output: The integer value stored in this expression.</returns>
        /// <remarks>
        /// The context parameter is ignored here, but is required to maintain
        /// a uniform interface across all expression types.
        /// </remarks>
        public int Interpret(Context context)
        {
            return _number;
        }
    }
}