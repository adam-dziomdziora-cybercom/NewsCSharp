using System;

namespace NewsCSharp
{
    public class Ref1Locals
    {
        private static void ReplaceWithoutRef(string[] values, Func<string, bool> predicate, string newValue)
        {
            var item = FindItemWithoutRef(values, predicate);
            var oldValue = item;
            item = newValue;
            Console.WriteLine("Replace: replaced value '{0}' to '{1}'. New text: '{2}'",
                oldValue, newValue, string.Join("", values));
        }

        private static string FindItemWithoutRef(string[] values, Func<string, bool> predicate)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    Console.WriteLine("FindIndex: found value '{0}' at index {1}", values[i], i);
                    return values[i];
                }
            }
            throw new InvalidOperationException("FindIndex: didn't find anything.");
        }

        private static void ReplaceRef(string[] values, Func<string, bool> predicate, string newValue)
        {
            ref var item = ref FindItemRef(values, predicate);
            var oldValue = item;
            item = newValue;
            Console.WriteLine("Replace: replaced value '{0}' to '{1}'. New text: '{2}'",
                oldValue, newValue, string.Join("", values));
        }

        private static ref string FindItemRef(string[] values, Func<string, bool> predicate)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (predicate(values[i]))
                {
                    Console.WriteLine("FindIndex: found value '{0}' at index {1}", values[i], i);
                    return ref values[i];
                }
            }
            throw new InvalidOperationException("FindIndex: didn't find anything.");
        }

        public static void ExampleReplace()
        {
            Console.WriteLine();
            Console.WriteLine("====== Ref 1 - Example Replace ======");

            Console.WriteLine("=== Without ref ===");
            var values = new[] { "cy", "ber", "com" };
            ReplaceWithoutRef(values, v => v == "com", "king");

            Console.WriteLine("=== With ref ===");
            var valuesRef = new[] { "cy", "ber", "com" };
            ReplaceRef(values, v => v == "com", "king");

            Console.WriteLine("====================================================================");
        }




    }
}