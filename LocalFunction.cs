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
    }
}