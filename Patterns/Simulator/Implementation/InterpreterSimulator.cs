//------------------------------------------------------------------------------
// <file>InterpreterSimulator.cs</file>
// <author>SoumyajitC</author>
// <date>2026-08-17</date>
// <summary>
//   Defines the InterpreterSimulator class that demonstrates the Interpreter Design Pattern.
//   Simulates both a generic example (assignment and arithmetic) and a typical math parser use case.
// </summary>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation;
using Patterns.Behavioral.Interpreter.GenericExample.Implementation.Realizations;
using Patterns.Behavioral.Interpreter.GenericExample.Interface;
using Patterns.Behavioral.Interpreter.TypicalExample.Implementation.Context;
using Patterns.Behavioral.Interpreter.TypicalExample.Implementation.MathParser;
using Patterns.Behavioral.Interpreter.TypicalExample.Interface;
using Patterns.Simulator.Interface;

namespace Patterns.Simulator.Implementation
{
    /// <summary>
    /// Simulator class for demonstrating the Interpreter Design Pattern.
    /// Runs both a generic example (variable assignment and arithmetic) and a typical math parser use case.
    /// </summary>
    internal class InterpreterSimulator : ISimulator
    {
        /// <summary>
        /// Executes the simulation of the Interpreter Design Pattern.
        /// </summary>
        /// <remarks>
        /// - Demonstrates variable assignment and arithmetic using the generic interpreter.  
        /// - Demonstrates parsing and evaluating a complex mathematical expression using the typical math parser.  
        /// Throws <see cref="InvalidOperationException"/> if the evaluated result does not match the expected value.
        /// </remarks>
        void ISimulator.Simulate()
        {
            // -------------------------------
            // Generic Example Simulation
            // -------------------------------
            Context context = new Context();

            // x = 5 + 3
            IExpression assignX = new AssignmentExpression(
                "x",
                new AddExpression(
                    new NumberExpression(5),
                    new NumberExpression(3)
                )
            );
            Console.WriteLine($"x = {assignX.Interpret(context)}"); // Output: 8

            // y = x - 2
            IExpression assignY = new AssignmentExpression(
                "y",
                new SubtractExpression(
                    new VariableExpression("x"),
                    new NumberExpression(2)
                )
            );
            Console.WriteLine($"y = {assignY.Interpret(context)}"); // Output: 6

            // Evaluate: y + 10
            IExpression expr = new AddExpression(
                new VariableExpression("y"),
                new NumberExpression(10)
            );
            Console.WriteLine($"y + 10 = {expr.Interpret(context)}"); // Output: 16

            Console.WriteLine("Interpreter Pattern Simulation Completed.");

            // -------------------------------
            // Typical Example Simulation
            // -------------------------------
            Console.WriteLine("Starting typical use case of interpreter");
            Console.WriteLine("Evaluating the expression: [{(a + b) - (c + d)}*10]%7");

            ExpressionContext contextT = new ExpressionContext();
            contextT.Set("a", 5);
            contextT.Set("b", 3);
            contextT.Set("c", 2);
            contextT.Set("d", 1);

            Lexer lexer = new Lexer("[{(a + b) - (c + d)}*10]%7");
            List<Token> tokens = lexer.Tokenize();

            Parser parser = new Parser(tokens, contextT);
            IExpressionT syntaxTree = parser.Parse();

            // Clean, parameterless evaluation matching IExpressionT interface
            double result = syntaxTree.Interpret();
            Console.WriteLine(result); // Outputs: 1

            if (result != 1)
            {
                throw new InvalidOperationException("The evaluated result should be 1.");
            }
            else
            {
                Console.WriteLine("The evaluated result is correct: 1");
            }

            Console.WriteLine("Interpreter Pattern Typical Use Case Simulation Completed.");
            Console.WriteLine("Press any key to continue...");
        }
    }
}