using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCSharp
{
    public static class MemoryAndSpan
    {
        private static async Task Something()
        {
            int secondsDelay = new Random().Next(2, 5);
            await Task.Delay(secondsDelay * 1000);
        }

        // private static async Task DoSomethingAsync(Span<int> buffer)
        // {
        //     buffer[0] = new Random().Next();
        //     await Something(); // Oops! The stack unwinds here, but the buffer below
        //                        // cannot survive the continuation.
        //     buffer[buffer.Length - 1] = new Random().Next();
        // }

        private static async Task DoSomethingAsync(Memory<int> buffer)
        {
            buffer.Span[0] = new Random().Next();
            await Something();
            buffer.Span[buffer.Length - 1] = new Random().Next();
        }

        public static async Task ExampleMemory()
        {
            Console.WriteLine();
            Console.WriteLine("====== Memory And Span - Example Memory ======");

            int[] values = Enumerable.Range(1, 10).ToArray();
            Memory<int> buffer = new Memory<int>(values);

            Console.WriteLine("Before manipulation: ");
            foreach (var value in buffer.ToArray())
            {
                Console.Write($"{value}, ");
            }

            await DoSomethingAsync(buffer);

            Console.WriteLine();
            Console.WriteLine("After manipulation: ");
            foreach (var value in buffer.ToArray())
            {
                Console.Write($"{value}, ");
            }

            Console.WriteLine();
            Console.WriteLine("====================================================================");
        }
    }
}