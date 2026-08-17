//------------------------------------------------------------------------------
// <file>NumberExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the NumberExpressionT class used in the Interpreter Design Pattern.
//   Represents a terminal expression that holds a numeric literal.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.TypicalExample.Interface;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a numeric literal in the Interpreter pattern.
    /// This is a terminal expression that simply returns its stored value.
    /// </summary>
    internal class NumberExpressionT : IExpressionT
    {
        private readonly double _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberExpressionT"/> class.
        /// </summary>
        /// <param name="value">Input: The numeric value to be stored and returned.</param>
        /// <remarks>
        /// This value is immutable once set in the constructor.
        /// </remarks>
        public NumberExpressionT(double value) => _value = value;

        /// <summary>
        /// Interprets the number expression.
        /// </summary>
        /// <returns>Output: The numeric value stored in this expression as a double.</returns>
        /// <remarks>
        /// This terminal expression does not depend on any context.
        /// </remarks>
        public double Interpret() => _value;
    }
}