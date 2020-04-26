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

        public static void ExampleFibonacci()
        {
            Console.WriteLine();
            Console.WriteLine("====== Value Tuples - Example Fibonacci ======");

            Console.WriteLine("=== Get Fibonacci Squares Area ===");
            const int fibonacciNumbers = 10;
            GetFibonacciSquaresArea(fibonacciNumbers);

            Console.WriteLine("=== Get Fibonacci Square By Id ===");
            var sumOfAreas = Enumerable.Range(1, fibonacciNumbers).Select(p =>
            {
                var (_, _, area) = GetFibonacciSquareById(p);
                return area;
            }).Sum(x => x);
            Console.WriteLine($"GetFibonacciSquareById: total area of {fibonacciNumbers} squares equals {sumOfAreas:n}");

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

        private static IEnumerable<(int id, long side, long area)> GetFibonacciSquares(int numberOfSquares)
        {
            long n2 = 1, n1 = 1, side = n1;
            var id = 1;
            yield return (id++, side, side * side);
            while (id <= numberOfSquares)
            {
                yield return (id++, side, side * side);
                side += n2;
                n2 = n1;
                n1 = side;
            };
        }

        private static long GetFibonacciSquaresArea(int numberOfSquares)
        {
            var squares = GetFibonacciSquares(numberOfSquares);
            var sumAreas = squares.Sum(sq => sq.area);
            Console.WriteLine("GetFibonacciSquaresArea: total area of {0} squares equals {1:n}", numberOfSquares, sumAreas);
            return sumAreas;
        }

        private static (int id, long side, long area) GetFibonacciSquareById(int id)
        {
            long n2 = 1, n1 = 1, side = n1;
            var currentId = 2;
            while (currentId < id)
            {
                side += n2;
                n2 = n1;
                n1 = side;
                currentId++;
            };
            return (id, side, side * side);
        }

        private static long GetFibonacciSquareAreaById(int id)
        {
            var (_, _, area) = GetFibonacciSquareById(id);
            Console.WriteLine("GetFibonacciSquareAreaById: area of square {0} equals {1:n}", id, area);
            return area;
        }
    }
}