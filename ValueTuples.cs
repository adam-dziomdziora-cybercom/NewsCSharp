using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsCSharp
{
    public static class ValueTuples
    {

        public static void ExampleTuples()
        {
            Console.WriteLine();
            Console.WriteLine("====== Value Tuples - Example Tuples ======");

            Console.WriteLine("=== Simple Tuple ===");
            var simpleTuple = GetSimpleTuple();
            Console.WriteLine($"simple tuple: {simpleTuple}");
            Console.WriteLine($"item2 of simple tuple: {simpleTuple.Item2}");
            var (_, _, onlyThirdValue) = simpleTuple;
            Console.WriteLine($"last item of simple tuple: { onlyThirdValue}");

            Console.WriteLine("=== Named Tuple ===");
            var namedTuple = GetNamedTuple();
            Console.WriteLine($"named tuple: {namedTuple}");
            Console.WriteLine($"inside of named tuple: {namedTuple.inside}");
            var (_, _, canITakeLastElementLikeThat) = namedTuple;
            Console.WriteLine($"last item of named tuple: { canITakeLastElementLikeThat}");

            Console.WriteLine("=== Deconstruct ===");
            var (_, _, whatIsAreaThen) = new MagicSquare(11, 41);
            Console.WriteLine($"area of MagicSquare: {whatIsAreaThen}");

            Console.WriteLine("====================================================================");
        }

        private static Tuple<string, string, string> GetSimpleTuple()
        {
            var tuple = Tuple.Create("cy", "ber", "com");
            return tuple;
        }

        private static (string companyPrefix, string inside, string lastButNotLeast) GetNamedTuple()
        {
            var namedTuple = (companyPrefix: "cy", inside: "ber", lastButNotLeast: "com");
            return namedTuple;
        }

        private struct MagicSquare
        {
            public MagicSquare(int id, long side)
            {
                Id = id;
                Side = side;
            }

            public int Id { get; }
            public long Side { get; }
            public long Area
            {
                get => Side * Side + Id;
            }

            public void Deconstruct(out int id, out long side, out long area)
            {
                id = Id;
                side = Side;
                area = Area;
            }
        }
    }
}