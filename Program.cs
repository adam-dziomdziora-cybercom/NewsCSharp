using System;
using System.Threading.Tasks;

namespace NewsCSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OutVariables.ExampleParsing();
            OutVariables.ExampleGetting();
            Discord.ExampleIsANumber();
            VariableLiterals.ExampleLiterals();
            ExpressionBodiedMembersWrapper.ExampleBodiedMembers();
            PatternMatching.ExampleParsing();
            PatternMatching.ExampleJoining();
            LocalFunction.ExampleOddSequence();
            LocalFunction.ExampleFibonacci();
            LocalFunction.ExampleClosestFibonacci();
            await LocalFunction.ExampleAsync();
        }
    }
}
