//------------------------------------------------------------------------------
// <file>Parser.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the Parser class used in the Interpreter Design Pattern.
//   Implements a recursive descent parser for mathematical expressions,
//   respecting operator precedence (BODMAS) and handling variables, literals,
//   and grouped expressions.
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Context;
using Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Realizations;
using Patterns.Behavioral.Interpreter.TypicalExample.Interface;

namespace Patterns.Behavioral.Interpreter.TypicalExample.Implementation.MathParser
{
    /// <summary>
    /// Recursive descent parser for mathematical expressions.
    /// Converts a list of tokens into an abstract syntax tree (AST)
    /// composed of <see cref="IExpressionT"/> nodes.
    /// </summary>
    internal class Parser
    {
        private readonly List<Token> _tokens;
        private int _currentIdx;
        private readonly ExpressionContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="tokens">Input: List of tokens produced by the lexer.</param>
        /// <param name="context">Input: Expression context for variable resolution.</param>
        /// <remarks>
        /// The parser consumes tokens sequentially and builds an AST.
        /// </remarks>
        public Parser(List<Token> tokens, ExpressionContext context)
        {
            _tokens = tokens ?? throw new ArgumentNullException(nameof(tokens), "Tokens cannot be null.");
            _currentIdx = 0;
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null.");
        }

        /// <summary>
        /// Peeks at the current token without advancing the index.
        /// </summary>
        /// <returns>Output: The current <see cref="Token"/>.</returns>
        private Token Peek() => _tokens[_currentIdx];

        /// <summary>
        /// Advances the index and returns the next token.
        /// </summary>
        /// <returns>Output: The next <see cref="Token"/>.</returns>
        private Token Advance() => _tokens[_currentIdx++];

        /// <summary>
        /// Parses the entire input into an expression tree.
        /// </summary>
        /// <returns>Output: Root <see cref="IExpressionT"/> of the AST.</returns>
        public IExpressionT Parse() => ParseExpression();

        /// <summary>
        /// Parses addition and subtraction expressions (lowest precedence).
        /// </summary>
        /// <returns>Output: <see cref="IExpressionT"/> representing addition/subtraction.</returns>
        private IExpressionT ParseExpression()
        {
            IExpressionT left = ParseTerm();

            while (Peek().Type is TokenType.Plus or TokenType.Minus)
            {
                left = Advance().Type switch
                {
                    TokenType.Plus => new AddExpressionT(left, ParseTerm()),
                    TokenType.Minus => new SubtractExpressionT(left, ParseTerm()),
                    _ => left
                };
            }

            return left;
        }

        /// <summary>
        /// Parses multiplication, division, modulo, and implicit multiplication.
        /// </summary>
        /// <returns>Output: <see cref="IExpressionT"/> representing term-level operations.</returns>
        private IExpressionT ParseTerm()
        {
            IExpressionT left = ParseFactor();

            while (Peek().Type is TokenType.Multiply or TokenType.Divide or TokenType.Modulo
                                    or TokenType.OpenParenthesis or TokenType.Variable)
            {
                left = Peek().Type switch
                {
                    // Implicit multiplication: a(b+c), 5a, or 2(3+1)
                    TokenType.OpenParenthesis or TokenType.Variable =>
                        new MultiplyExpressionT(left, ParseFactor()),

                    // Explicit binary operators (*, /, %)
                    _ => Advance().Type switch
                    {
                        TokenType.Multiply => new MultiplyExpressionT(left, ParseFactor()),
                        TokenType.Divide => new DivideExpressionT(left, ParseFactor()),
                        TokenType.Modulo => new OddExpressionT(left, ParseFactor()),
                        _ => left
                    }
                };
            }

            return left;
        }

        /// <summary>
        /// Parses grouped expressions, variables, and numeric literals (highest precedence).
        /// </summary>
        /// <returns>Output: <see cref="IExpressionT"/> representing a factor.</returns>
        private IExpressionT ParseFactor()
        {
            return Peek().Type switch
            {
                TokenType.OpenParenthesis => ParseGroupedExpression(),
                TokenType.Number => new NumberExpressionT(double.Parse(Advance().Value)),
                TokenType.Variable => new VariableExpressionT(Advance().Value, _context),
                TokenType.CloseParenthesis => throw new FormatException(
                    $"Syntactic error: Unexpected closing bracket '{Peek().Value}' with no matching opening bracket."),
                _ => throw new FormatException(
                    $"Syntactic error: Unexpected token '{Peek().Value}' ({Peek().Type}) at index {_currentIdx}.")
            };
        }

        /// <summary>
        /// Parses grouped expressions enclosed in parentheses, brackets, or braces.
        /// </summary>
        /// <returns>Output: <see cref="IExpressionT"/> representing the inner expression.</returns>
        /// <remarks>
        /// Validates matching bracket pairs and throws <see cref="FormatException"/> if mismatched.
        /// </remarks>
        private IExpressionT ParseGroupedExpression()
        {
            Token openToken = Advance(); // e.g., '(', '[', or '{'
            IExpressionT inner = ParseExpression();

            Token closeToken = Advance(); // Expected ')', ']', or '}'

            if (closeToken.Type != TokenType.CloseParenthesis)
            {
                throw new FormatException(
                    $"Syntactic error: Expected closing bracket for '{openToken.Value}' but found '{closeToken.Value}'.");
            }

            // Verify corresponding bracket pairs match
            char expectedClose = openToken.Value switch
            {
                "(" => ')',
                "[" => ']',
                "{" => '}',
                _ => ')'
            };

            if (closeToken.Value[0] != expectedClose)
            {
                throw new FormatException(
                    $"Mismatched brackets: Opened with '{openToken.Value}' but closed with '{closeToken.Value}'. Expected '{expectedClose}'.");
            }

            return inner;
        }
    }
}