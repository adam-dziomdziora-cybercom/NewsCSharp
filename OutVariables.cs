using System;
using System.Collections.Generic;
using System.Globalization;

namespace NewsCSharp
{
    public static class OutVariables
    {
        public static float ParseToFloat(dynamic var)
        {
            float result;
            float.TryParse(var, out result);

            return result;
        }

        public static float ParseToFloatUsingOut(dynamic var)
        {
            float.TryParse(var, out float result);

            return result;
        }

        public static void ExampleParsing()
        {
            var test1 = "1.23";
            var test2 = $"1{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}23";
            var test3 = "1,23";

            var parsedValues = new List<float>();
            var parsedValuesUsingOut = new List<float>();

            parsedValues.Add(OutVariables.ParseToFloat(test1));
            parsedValues.Add(OutVariables.ParseToFloat(test2));
            parsedValues.Add(OutVariables.ParseToFloat(test3));

            parsedValuesUsingOut.Add(OutVariables.ParseToFloatUsingOut(test1));
            parsedValuesUsingOut.Add(OutVariables.ParseToFloatUsingOut(test2));
            parsedValuesUsingOut.Add(OutVariables.ParseToFloatUsingOut(test3));

            Log(parsedValues);
            Console.WriteLine($"=== NOW USING OUT ===");
            Log(parsedValuesUsingOut);
        }

        private static void Log<T>(IEnumerable<T> list)
        {
            foreach (var val in list)
            {
                Console.WriteLine($"result of parsing: {val}");
            }
        }
    }
}