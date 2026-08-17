//------------------------------------------------------------------------------
// <file>VariableExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the VariableExpression class used in the Interpreter Design Pattern.
//   Represents a terminal expression that retrieves the value of a variable
//   from the given context.
// </summary>
//------------------------------------------------------------------------------

using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations
{
    /// <summary>
    /// Represents a variable in the Interpreter pattern.
    /// This is a terminal expression that looks up its value in the provided context.
    /// </summary>
    internal class VariableExpression : IExpression
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableExpression"/> class.
        /// </summary>
        /// <param name="name">Input: The name of the variable to be retrieved.</param>
        /// <remarks>
        /// The variable name is stored as-is and used for lookup in the context.
        /// </remarks>
        public VariableExpression(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name), "Variable name cannot be null.");
        }

        /// <summary>
        /// Interprets the variable expression using the provided context.
        /// </summary>
        /// <param name="context">Input: Context object containing variable mappings.</param>
        /// <returns>Output: The integer value of the variable.</returns>
        /// <remarks>
        /// Throws <see cref="ArgumentNullException"/> if the context is null.
        /// If the variable does not exist in the context, the context returns 0 by default.
        /// </remarks>
        public int Interpret(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context cannot be null.");
            }

            return context.GetVariable(_name);
        }
    }
}