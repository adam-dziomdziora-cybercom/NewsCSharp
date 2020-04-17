using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsCSharp
{
    public static class LocalFunction
    {
        public static IEnumerable<int> OddSequence(int start, int end)
        {
            if (start < 0 || start > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            }
            if (end > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            }
            if (start >= end)
            {
                throw new ArgumentException("start must be less than end.", nameof(start));
            }

            for (var i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<int> OddSequenceWithLocal(int start, int end)
        {
            if (start < 0 || start > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            }
            if (end > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            }
            if (start >= end)
            {
                throw new ArgumentException("start must be less than end.", nameof(start));
            }

            return GetOddSequenceEnumerator();

            IEnumerable<int> GetOddSequenceEnumerator()
            {
                for (var i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                    {
                        yield return i;
                    }
                }
            }
        }

        public static void ExampleOddSequence()
        {
            Console.WriteLine();
            Console.WriteLine("====== Local Function - Example Odd Sequence ======");

            Console.WriteLine("=== OLD ===");
            try
            {
                var sequence = OddSequence(50, 101);
                Console.WriteLine("Retrieved enumerator...");
                foreach (var i in sequence)
                {
                    Console.Write($"{i} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("=== NEW ===");
            try
            {
                var sequenceWithLocal = OddSequenceWithLocal(50, 101);
                Console.WriteLine("Retrieved enumerator from local...");
                foreach (var i in sequenceWithLocal)
                {
                    Console.Write($"{i} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            Console.WriteLine();
            Console.WriteLine("====================================================================");
        }

        private static IEnumerable<int> GetFibonacciSequence(long maxValue)
        {
            if (maxValue < 1 || maxValue > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"Maximum value must be between 1 and {int.MaxValue}.");
            }

            int n1 = 1, n2 = 1;
            yield return n1;
            for (var at = n1; at <= maxValue; at = n2 + n1)
            {
                yield return at;
                n2 = n1;
                n1 = at;

                // this part prevents against the System.OutOfMemoryException
                long test1 = n1, test2 = n2;
                if (test1 + test1 > int.MaxValue)
                {
                    break;
                }
            }
        }

        private static IEnumerable<int> GetFibonacciSequenceWithLocal(long maxValue)
        {
            if (maxValue < 1 || maxValue > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"Maximum value must be between 1 and {int.MaxValue}.");
            }
            return getFibonacciSequence();

            IEnumerable<int> getFibonacciSequence()
            {
                int n1 = 1, n2 = 1;
                yield return n1;
                for (var at = n1; at <= maxValue; at = n2 + n1)
                {
                    yield return at;
                    n2 = n1;
                    n1 = at;

                    // this part prevents against the System.OutOfMemoryException
                    long test1 = n1, test2 = n2;
                    if (test1 + test1 > int.MaxValue)
                    {
                        break;
                    }
                }
            }
        }

        public static void ExampleFibonacci()
        {
            Console.WriteLine();
            Console.WriteLine("====== Local Function - Example Fibonacci ======");

            long maxValue = (long)int.MaxValue + 1;

            Console.WriteLine("=== OLD ===");
            try
            {
                var result = GetFibonacciSequence(maxValue);
                Console.WriteLine("Fibonacci... ");
                Console.WriteLine("GetFibonacciSequence ({0}): {1}", maxValue, string.Join(", ", result));
            }
            catch (Exception e)
            {
                Console.WriteLine("GetFibonacciSequence ({0}): {1}", maxValue, e);
            }

            Console.WriteLine("=== NEW ===");
            try
            {
                var result = GetFibonacciSequenceWithLocal(maxValue);
                Console.WriteLine("Fibonacci with local... ");
                Console.WriteLine("GetFibonacciSequence ({0}): {1}", maxValue, string.Join(", ", result));
            }
            catch (Exception e)
            {
                Console.WriteLine("GetFibonacciSequence ({0}): {1}", maxValue, e);
            }

            Console.WriteLine("====================================================================");
        }
    }
}