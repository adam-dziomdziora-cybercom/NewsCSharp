using System;
using System.Diagnostics;
using System.Linq;

namespace NewsCSharp
{
    public static class StringAsSpan
    {
        private static bool IsNullOrEmpty(string s)
        {
            bool nullOrEmpty;

            var sw = Stopwatch.StartNew();
            nullOrEmpty = string.IsNullOrEmpty(s);
            sw.Stop();

            var ss = s?.Take(10) ?? new char[0];
            var stringToPrint = new String(ss.ToArray()) + " ...";

            Console.WriteLine("IsNullOrEmpty: '{0}' => {1}. Completed in {2}.", stringToPrint, nullOrEmpty, sw.Elapsed);

            sw.Restart();
            nullOrEmpty = s.AsSpan().IsEmpty;
            sw.Stop();

            Console.WriteLine("IsNullOrEmpty: '{0}'.AsSpan() => {1}. Completed in {2}.", stringToPrint, nullOrEmpty, sw.Elapsed);

            return nullOrEmpty;
        }

        public static void ExampleIsNullOrEmpty()
        {
            Console.WriteLine();
            Console.WriteLine("====== String As Span - Example Is Null Or Empty ======");

            const string s1 = "";
            const string s2 = null;
            const string s3 = ".";
            const string s4 = "This is quite a long string which we should take care about, shouldn't we?";
            var r = new Random();
            var s5 = Enumerable.Range(1, 100_000).Select((t) =>
            {
                return r.Next(1, 10).ToString();
            }).ToList().Aggregate((a, b) => a + b);
            IsNullOrEmpty(s1);
            IsNullOrEmpty(s2);
            IsNullOrEmpty(s3);
            IsNullOrEmpty(s4);
            IsNullOrEmpty(s5);

            Console.WriteLine("====================================================================");
        }

        private static string ToUpper(string s)
        {
            string result;

            var sw = Stopwatch.StartNew();
            result = s.ToUpper();
            sw.Stop();
            Console.WriteLine("ToUpper: '{0}' => '{1}'. Completed in {2}.", s, result, sw.Elapsed);

            Span<char> sUpper = stackalloc char[s.Length];
            sw.Restart();
            s.AsSpan().ToUpperInvariant(sUpper);
            result = sUpper.ToString();
            sw.Stop();

            Console.WriteLine("ToUpper: '{0}'.AsSpan() => '{1}'. Completed in {2}.", s, result, sw.Elapsed);

            return result;
        }

        public static void ExampleToUpper()
        {
            Console.WriteLine();
            Console.WriteLine("====== String As Span - Example To Upper ======");

            const string s = "This is quite a long string which we should take care about, shouldn't we?";
            ToUpper(s);

            Console.WriteLine("====================================================================");
        }
    }
}