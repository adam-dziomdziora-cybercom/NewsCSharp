using System;

namespace NewsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OutVariables.ExampleParsing();
            OutVariables.ExampleGetting();
            Discord.ExampleIsANumber();
            VariableLiterals.ExampleLiterals();
            ExpressionBodiedMembersWrapper.ExampleBodiedMembers();
            PatternMatching.ExampleParsing();
        }
    }
}
