//------------------------------------------------------------------------------
// <file>Lexer.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the Lexer class used in the Interpreter Design Pattern.
//   Provides lexical analysis (tokenization) for mathematical expressions,
//   converting raw input strings into a sequence of tokens.
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.MathParser
{
    /// <summary>
    /// Lexical analyzer (Lexer) for tokenizing mathematical expressions.
    /// Converts raw input strings into a sequence of tokens representing
    /// numbers, variables, operators, and parentheses.
    /// </summary>
    internal class Lexer
    {
        private readonly string _src;
        private int _pos = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lexer"/> class.
        /// </summary>
        /// <param name="input">Input: The raw mathematical expression string.</param>
        /// <remarks>
        /// The input string is stored internally and processed character by character.
        /// </remarks>
        public Lexer(string input) => _src = input ?? throw new ArgumentNullException(nameof(input), "Input cannot be null.");

        /// <summary>
        /// Peeks at the current character without advancing the position.
        /// </summary>
        /// <returns>Output: The current character, or '\0' if end of input is reached.</returns>
        private char Peek() => _pos < _src.Length ? _src[_pos] : '\0';

        /// <summary>
        /// Advances the position and returns the next character.
        /// </summary>
        /// <returns>Output: The next character, or '\0' if end of input is reached.</returns>
        private char Advance() => _pos < _src.Length ? _src[_pos++] : '\0';

        /// <summary>
        /// Tokenizes the input string into a list of tokens.
        /// </summary>
        /// <returns>Output: A list of <see cref="Token"/> objects representing the parsed input.</returns>
        /// <remarks>
        /// - Supports parentheses (), [], {}  
        /// - Supports arithmetic operators (+, -, *, /, %)  
        /// - Supports numeric literals (integers and floating-point numbers)  
        /// - Supports identifiers/variables (letters, digits, underscores)  
        /// Throws <see cref="FormatException"/> if an unknown character is encountered.
        /// </remarks>
        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            while (_pos < _src.Length)
            {
                char current = Peek();

                if (char.IsWhiteSpace(current))
                {
                    Advance();
                    continue;
                }

                // 1. Opening and Closing Brackets
                if (current is '(' or '[' or '{')
                {
                    tokens.Add(new Token(TokenType.OpenParenthesis, Advance().ToString()));
                    continue;
                }

                if (current is ')' or ']' or '}')
                {
                    tokens.Add(new Token(TokenType.CloseParenthesis, Advance().ToString()));
                    continue;
                }

                // 2. Arithmetic Operators
                if (current is '+' or '-' or '*' or '/' or '%')
                {
                    TokenType opType = current switch
                    {
                        '+' => TokenType.Plus,
                        '-' => TokenType.Minus,
                        '*' => TokenType.Multiply,
                        '/' => TokenType.Divide,
                        '%' => TokenType.Modulo,
                        _ => throw new InvalidOperationException()
                    };

                    tokens.Add(new Token(opType, Advance().ToString()));
                    continue;
                }

                // 3. Numeric Literals
                if (char.IsDigit(current) || current == '.')
                {
                    int start = _pos;
                    while (char.IsDigit(Peek()) || Peek() == '.')
                    {
                        Advance();
                    }

                    tokens.Add(new Token(TokenType.Number, _src.Substring(start, _pos - start)));
                    continue;
                }

                // 4. Identifiers / Variables
                if (char.IsLetter(current) || current == '_')
                {
                    int start = _pos;
                    while (char.IsLetterOrDigit(Peek()) || Peek() == '_')
                    {
                        Advance();
                    }

                    tokens.Add(new Token(TokenType.Variable, _src.Substring(start, _pos - start)));
                    continue;
                }

                throw new FormatException($"Lexical scanning error: Unknown character '{current}' at index {_pos}");
            }

            tokens.Add(new Token(TokenType.EOF));
            return tokens;
        }
    }
}