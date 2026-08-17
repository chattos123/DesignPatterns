//------------------------------------------------------------------------------
// <file>VariableExpressionT.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the VariableExpressionT class used in the Interpreter Design Pattern.
//   Represents a terminal expression that retrieves the value of a variable
//   from the provided ExpressionContext.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.TypicalExample.Interface;
using Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Context;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a variable in the Interpreter pattern.
    /// This is a terminal expression that looks up its value in the provided context.
    /// </summary>
    internal class VariableExpressionT : IExpressionT
    {
        private readonly string _name;
        private readonly ExpressionContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableExpressionT"/> class.
        /// </summary>
        /// <param name="name">Input: The name of the variable to be retrieved.</param>
        /// <param name="context">Input: The expression context containing variable mappings.</param>
        /// <remarks>
        /// Both parameters must be non-null. The variable name is stored as-is and used for lookup in the context.
        /// </remarks>
        public VariableExpressionT(string name, ExpressionContext context)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name), "Variable name cannot be null.");
            _context = context ?? throw new ArgumentNullException(nameof(context), "Expression context cannot be null.");
        }

        /// <summary>
        /// Interprets the variable expression using the provided context.
        /// </summary>
        /// <returns>Output: The numeric value of the variable as a double.</returns>
        /// <remarks>
        /// Throws <see cref="KeyNotFoundException"/> if the variable is not defined in the context.
        /// </remarks>
        public double Interpret() => _context.Get(_name);
    }
}