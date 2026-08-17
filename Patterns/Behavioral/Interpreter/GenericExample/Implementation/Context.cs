//------------------------------------------------------------------------------
// <file>Context.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the Context class used in the Interpreter Design Pattern.
//   Provides storage and retrieval of variable values for expression evaluation.
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Interpreter.GenericExample.Implementation
{
    /// <summary>
    /// Context class for the Interpreter pattern.
    /// Maintains a dictionary of variables and their values.
    /// Provides methods to set and get variable values during interpretation.
    /// </summary>
    internal class Context
    {
        private readonly Dictionary<string, int> _variables = new();

        /// <summary>
        /// Sets the value of a variable in the context.
        /// </summary>
        /// <param name="name">Input variable name (string).</param>
        /// <param name="value">Input variable value (int).</param>
        /// <remarks>
        /// If the variable already exists, its value is updated.
        /// </remarks>
        public void SetVariable(string name, int value) => _variables[name] = value;

        /// <summary>
        /// Retrieves the value of a variable from the context.
        /// </summary>
        /// <param name="name">Input variable name (string).</param>
        /// <returns>Returns the variable value (int).</returns>
        /// <remarks>
        /// If the variable does not exist, returns 0 by default.
        /// </remarks>
        public int GetVariable(string name) => _variables.ContainsKey(name) ? _variables[name] : 0;
    }
}
