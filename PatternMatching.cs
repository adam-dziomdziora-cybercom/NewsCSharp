using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string JoinStringOld(string separator, params object[] values)
        {
            var filteredValues = new List<string>(values.Length);
            foreach (var item in values)
            {
                // null checking must be first condition; otherwise code would explode
                if (item == null)
                {
                    Console.WriteLine("Join String: ignored null");
                }
                else if (item.GetType() == typeof(string))
                {
                    var s = item as string;
                    filteredValues.Add(s);
                }
                else if (item as IEnumerable<string> != null && (item as IEnumerable<string>).Any())
                {
                    var multiS = item as IEnumerable<string>;
                    filteredValues.Add(string.Join(string.Empty, multiS));
                }
                else
                {
                    Console.WriteLine($"Join String: skipping not supported value '{item}'");
                }
            }
            var result = string.Join(separator, filteredValues);
            Console.WriteLine($"Join String result: {result}");
            return result;
        }

        public static string JoinString(string separator, params object[] values)
        {
            var filteredValues = new List<string>(values.Length);
            foreach (var item in values)
            {
                switch (item)
                {
                    case string s:
                        {
                            filteredValues.Add(s);
                            break;
                        }
                    case IEnumerable<string> multiS when multiS.Any():
                        {
                            filteredValues.Add(string.Join(string.Empty, multiS));
                            break;
                        }
                    // notice that case null can be in different order and code won't explode!
                    case null:
                        {
                            Console.WriteLine("Join String: ignored null");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Join String: skipping not supported value '{item}'");
                            break;
                        }
                }
            }
            var result = string.Join(separator, filteredValues);
            Console.WriteLine($"Join String result: {result}");
            return result;
        }

        public static void ExampleJoining()
        {
            Console.WriteLine();
            Console.WriteLine("====== Pattern Matching - Example Joining ======");

            const string separator = ", ";

            Console.WriteLine("=== OLD ===");
            JoinStringOld(separator, "value1", new[] { "val", "ue2" }, new string[0], null, 123, DateTime.Now);


            Console.WriteLine("=== NEW ===");
            JoinString(separator, "value1", new[] { "val", "ue2" }, new string[0], null, 123, DateTime.Now);

            Console.WriteLine("====================================================================");
        }
    }
}