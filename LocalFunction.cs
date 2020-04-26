using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsCSharp
{
    public static class LocalFunction
    {
        private static IEnumerable<int> OddSequence(int start, int end)
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

        private static IEnumerable<int> OddSequenceWithLocal(int start, int end)
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

        private static int FindClosestFibonacciNumber(int number)
        {
            if (number < 1 || number > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Maximum value must be between 1 and {int.MaxValue}.");
            }
            var n1 = 1;
            var n2 = 1;
            var at = n1 + n2;

            while (at <= number)
            {
                // this part prevents against the System.OutOfMemoryException
                long test1 = n1, test2 = n2;
                if (test1 + test2 > int.MaxValue)
                {
                    break;
                }

                at = n2 + n1;
                n2 = n1;
                n1 = at;
                if (at > number)
                {
                    break;
                }
            }
            return n1;
        }

        private static int FindClosestFibonacciNumberWithLocal(int number)
        {
            if (number < 1 || number > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Maximum value must be between 1 and {int.MaxValue}.");
            }
            var fibNumber = getNextFibonacciNumber(1, 1);
            return fibNumber;

            int getNextFibonacciNumber(int n2, int n1)
            {
                // this part prevents against the System.OutOfMemoryException
                long test1 = n1, test2 = n2;
                if (test1 + test2 > int.MaxValue)
                {
                    return n1;
                }

                var at = n2 + n1;
                if (at > number)
                {
                    return n1;
                }
                return getNextFibonacciNumber(n1, at);
            };
        }

        public static void ExampleClosestFibonacci()
        {
            Console.WriteLine();
            Console.WriteLine("====== Local Function - Example Closest Fibonacci ======");

            int maxValue = int.MaxValue;

            Console.WriteLine("=== OLD ===");
            try
            {
                var result = FindClosestFibonacciNumber(maxValue);
                Console.WriteLine("Closest Fibonacci... ");
                Console.WriteLine("FindClosestFibonacciNumber ({0}): {1}", maxValue, result);
            }
            catch (Exception e)
            {
                Console.WriteLine("FindClosestFibonacciNumber ({0}): {1}", maxValue, e);
            }

            Console.WriteLine("=== NEW ===");
            try
            {
                var result = FindClosestFibonacciNumberWithLocal(maxValue);
                Console.WriteLine("Closest Fibonacci with local... ");
                Console.WriteLine("FindClosestFibonacciNumber ({0}): {1}", maxValue, result);
            }
            catch (Exception e)
            {
                Console.WriteLine("FindClosestFibonacciNumber ({0}): {1}", maxValue, e);
            }

            Console.WriteLine("====================================================================");
        }

        private static async Task<int> GetMultipleAsync(int secondsDelay)
        {
            if (secondsDelay < 0 || secondsDelay > 5)
            {
                throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5.");
            }

            await Task.Delay(secondsDelay * 1000);
            return secondsDelay * new Random().Next(2, 10);
        }

        private static async Task<int> GetMultipleWithLocal(int secondsDelay)
        {
            if (secondsDelay < 0 || secondsDelay > 5)
            {
                throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5.");
            }

            return await GetValueAsync();

            async Task<int> GetValueAsync()
            {
                await Task.Delay(secondsDelay * 1000);
                return secondsDelay * new Random().Next(2, 10);
            }
        }

        public static async Task ExampleAsync()
        {
            Console.WriteLine();
            Console.WriteLine("====== Local Function - Example Async ======");
            try
            {
                Console.WriteLine("Executing GetMultipleAsync...");

                var res = await GetMultipleAsync(6);
                Console.WriteLine("Executing GetValueAsync from Local...");

                Console.WriteLine($"Result: {res}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=== END OF GetMultipleAsync ===");
            Console.WriteLine();

            try
            {
                var res = await GetMultipleWithLocal(6);
                Console.WriteLine("Executing GetValueAsync...");
                Console.WriteLine($"Result: {res}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=== END OF GetMultipleAsync from Local ===");

            Console.WriteLine("====================================================================");
        }
    }
}