using System;

namespace NewsCSharp
{
    public static class PatternMatching
    {
        public static int ParseStringToIntOld(string s)
        {
            int result = 0;

            try
            {
                result = int.Parse(s);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentNullException))
                {
                    Console.WriteLine($"ParseInt: ArgumentNullException has been thrown. Exception: {ex}");
                }
                else if (ex.GetType() == typeof(FormatException))
                {
                    var formatException = ex as FormatException;
                    Console.WriteLine($"ParseInt: FormatException has been thrown. Exception: {formatException}");
                }
                else
                {
                    Console.WriteLine($"ParseInt: Exception has been thrown. Exception: {ex}");
                }
            }

            return result;
        }

        public static int ParseStringToInt(string s)
        {
            int result = 0;

            try
            {
                result = int.Parse(s);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                {
                    Console.WriteLine($"ParseInt: ArgumentNullException has been thrown. Exception: {ex}");
                }
                else if (ex is FormatException formatException)
                {
                    Console.WriteLine($"ParseInt: FormatException has been thrown. Exception: {formatException}");
                }
                else
                {
                    Console.WriteLine($"ParseInt: Exception has been thrown. Exception: {ex}");
                }
            }

            return result;
        }

        public static void ExampleParsing()
        {
            Console.WriteLine();
            Console.WriteLine("====== Pattern Matching - Example Parsing ======");

            Console.WriteLine("=== OLD ===");
            ParseStringToIntOld(null);
            ParseStringToIntOld("sample incorrect string");
            ParseStringToIntOld("999999999999999999999999999999999999999999999");
            ParseStringToIntOld("-999999999999999999999999999999999999999999999");

            Console.WriteLine("=== NEW ===");
            ParseStringToInt(null);
            ParseStringToInt("sample incorrect string");
            ParseStringToInt("999999999999999999999999999999999999999999999");
            ParseStringToInt("-999999999999999999999999999999999999999999999");

            Console.WriteLine("====================================================================");
        }
    }
}