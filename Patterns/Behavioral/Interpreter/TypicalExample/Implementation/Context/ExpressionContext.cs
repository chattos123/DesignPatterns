//------------------------------------------------------------------------------
// <file>ExpressionContext.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the ExpressionContext class used in the Interpreter Design Pattern.
//   Provides storage and retrieval of variable values for expression evaluation.
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Context
{
    /// <summary>
    /// Context class for the Interpreter pattern.
    /// Maintains a dictionary of variables and their values.
    /// Provides methods to set and get variable values during interpretation.
    /// </summary>
    internal class ExpressionContext
    {
        private readonly Dictionary<string, double> _variables = new();

        /// <summary>
        /// Sets the value of a variable in the context.
        /// </summary>
        /// <param name="name">Input: Variable name (string).</param>
        /// <param name="value">Input: Variable value (double).</param>
        /// <remarks>
        /// If the variable already exists, its value is updated.
        /// </remarks>
        public void Set(string name, double value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Variable name cannot be null or whitespace.", nameof(name));
            }

            _variables[name] = value;
        }

        /// <summary>
        /// Retrieves the value of a variable from the context.
        /// </summary>
        /// <param name="name">Input: Variable name (string).</param>
        /// <returns>Output: The variable value (double).</returns>
        /// <remarks>
        /// Throws <see cref="KeyNotFoundException"/> if the variable is not defined in the context.
        /// </remarks>
        public double Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Variable name cannot be null or whitespace.", nameof(name));
            }

            return _variables.TryGetValue(name, out var val)
                ? val
                : throw new KeyNotFoundException($"Variable '{name}' is undefined.");
        }
    }
}