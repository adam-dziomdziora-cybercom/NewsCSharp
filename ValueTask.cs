using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCSharp
{
    public static class ValueTask
    {
        static string[] _cachedValues;
        private static async Task<IEnumerable<string>> LoadValues()
        {
            await Task.Delay(3000);
            _cachedValues = new[] { "cy", "ber", "com" };
            return _cachedValues;
        }

        private static ValueTask<IEnumerable<string>> GetValues()
        {
            if (_cachedValues == null)
            {
                Console.WriteLine("GetValues: values loaded from outside.");
                return new ValueTask<IEnumerable<string>>(LoadValues());
            }

            Console.WriteLine($"GetValues: values loaded from cache: {string.Join(", ", _cachedValues)}");
            return new ValueTask<IEnumerable<string>>(_cachedValues);
        }

        public static async Task ExampleTask()
        {
            Console.WriteLine();
            Console.WriteLine("====== Value Task - Example Task ======");

            const int minAttempts = 5;
            const int maxAttempts = 10;
            var attempts = new Random().Next(minAttempts, maxAttempts);

            Console.WriteLine($"=== Executing {attempts} times Get Values...");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < attempts; i++)
            {
                await GetValues();
            }
            sw.Stop();
            Console.WriteLine($"execution time: {sw.Elapsed}");

            Console.WriteLine("====================================================================");
        }

    }
}