//------------------------------------------------------------------------------
// <file>AssignmentExpression.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the AssignmentExpression class used in the Interpreter Design Pattern.
//   Represents a non-terminal expression that assigns the result of an expression
//   to a variable within the given context.
// </summary>
//------------------------------------------------------------------------------

using System;
using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations
{
    /// <summary>
    /// Represents an assignment operation in the Interpreter pattern.
    /// Evaluates the right-hand side expression and stores the result
    /// in the context under the specified variable name.
    /// </summary>
    internal class AssignmentExpression : IExpression
    {
        private readonly string _variableName;
        private readonly IExpression _expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentExpression"/> class.
        /// </summary>
        /// <param name="variableName">Input: The name of the variable to assign.</param>
        /// <param name="expression">Input: The expression whose result will be assigned.</param>
        /// <remarks>
        /// Both parameters must be non-null. The variable name is stored as-is.
        /// </remarks>
        public AssignmentExpression(string variableName, IExpression expression)
        {
            _variableName = variableName ?? throw new ArgumentNullException(nameof(variableName), "Variable name cannot be null.");
            _expression = expression ?? throw new ArgumentNullException(nameof(expression), "Expression cannot be null.");
        }

        /// <summary>
        /// Interprets the assignment expression using the provided context.
        /// </summary>
        /// <param name="context">Input: Context object containing variable mappings.</param>
        /// <returns>Output: The integer value assigned to the variable.</returns>
        /// <remarks>
        /// Throws <see cref="ArgumentNullException"/> if the context is null.
        /// </remarks>
        public int Interpret(Context context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context cannot be null.");
            }

            // Evaluate the right-hand side expression
            int value = _expression.Interpret(context);

            // Store the result in the context under the given variable name
            context.SetVariable(_variableName, value);

            // Return the assigned value
            return value;
        }
    }
}