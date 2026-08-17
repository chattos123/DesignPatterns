//------------------------------------------------------------------------------
// <file>Token.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the TokenType enumeration and Token class used in the Interpreter Design Pattern.
//   Provides lexical tokens representing numbers, variables, operators, parentheses, and EOF.
// </summary>
//------------------------------------------------------------------------------

using System;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.MathParser
{
    /// <summary>
    /// Enumeration of possible token types for mathematical expressions.
    /// </summary>
    public enum TokenType
    {
        /// <summary>Represents a numeric literal.</summary>
        Number,

        /// <summary>Represents a variable identifier.</summary>
        Variable,

        /// <summary>Represents the addition operator (+).</summary>
        Plus,

        /// <summary>Represents the subtraction operator (-).</summary>
        Minus,

        /// <summary>Represents the multiplication operator (*).</summary>
        Multiply,

        /// <summary>Represents the division operator (/).</summary>
        Divide,

        /// <summary>Represents the modulo operator (%).</summary>
        Modulo,

        /// <summary>Represents an opening parenthesis ( (, [, { ).</summary>
        OpenParenthesis,

        /// <summary>Represents a closing parenthesis ( ), ], } ).</summary>
        CloseParenthesis,

        /// <summary>Represents the end of input.</summary>
        EOF
    }

    /// <summary>
    /// Represents a lexical token produced by the lexer.
    /// Contains the token type and its associated string value.
    /// </summary>
    internal class Token
    {
        /// <summary>
        /// Gets the type of the token.
        /// </summary>
        public TokenType Type { get; }

        /// <summary>
        /// Gets the string value of the token.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="type">Input: The type of the token.</param>
        /// <param name="value">Input: The string value of the token (default empty).</param>
        /// <remarks>
        /// For operators and parentheses, the value preserves the exact character.
        /// For numbers and variables, the value stores the literal string representation.
        /// </remarks>
        public Token(TokenType type, string value = "")
        {
            Type = type;
            Value = value ?? string.Empty;
        }

        /// <summary>
        /// Returns a string representation of the token.
        /// </summary>
        /// <returns>Output: A formatted string showing type and value.</returns>
        public override string ToString() => $"{Type}: '{Value}'";
    }
}