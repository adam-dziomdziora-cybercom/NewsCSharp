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
            StringAsSpan.ExampleIsNullOrEmpty();
            StringAsSpan.ExampleToUpper();
            await MemoryAndSpan.ExampleMemory();
            Ref1Locals.ExampleReplace();
            Ref2Semantics.ExampleSemantics();
            ValueTuples.ExampleTuples();
            ValueTuples.ExampleFibonacci();
            await ValueTask.ExampleTask();
        }
    }
}
