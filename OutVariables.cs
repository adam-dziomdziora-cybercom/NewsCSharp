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

        public static double ParseToDouble(dynamic var)
        {
            double result;
            if (double.TryParse(var, out result))
            {
                // On .NET Core 3.0 and later versions, it returns Double.NegativeInfinity if you attempt to parse MinValue
                // or Double.PositiveInfinity if you attempt to parse MaxValue.
                Console.WriteLine(result);
            }
            else
            {
                // On .NET Framework and .NET Core 2.2 and previous versions, it throws an OverflowException.
                // then this part of the code is executed
                Console.WriteLine("{0} is outside the range of a Double.", var);
            }
            return result;
        }

        public static double ParseToDoubleUsingOut(dynamic var)
        {
            if (double.TryParse(var, out double result))
            {
                // On .NET Core 3.0 and later versions, it returns Double.NegativeInfinity if you attempt to parse MinValue
                // or Double.PositiveInfinity if you attempt to parse MaxValue.
                Console.WriteLine(result);
            }
            else
            {
                // On .NET Framework and .NET Core 2.2 and previous versions, it throws an OverflowException.
                // then this part of the code is executed
                Console.WriteLine("{0} is outside the range of a Double.", result);
            }
            return result;
        }

        public static string GetDictionaryValue(IDictionary<string, string> var, string key)
        {
            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (var.TryGetValue(key, out value))
            {
                Console.WriteLine($"For \"{key}\", value = {value}.");
            }
            else
            {
                Console.WriteLine($"Key \"{key}\" is not found.");
            }
            return value;
        }

        public static string GetDictionaryValueUsingOut(IDictionary<string, string> var, string key)
        {
            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
            // way to retrieve values.   
            if (var.TryGetValue(key, out string value))
            {
                Console.WriteLine($"For \"{key}\", value = {value}.");
            }
            else
            {
                Console.WriteLine($"Key \"{key}\" is not found.");
            }
            return value;
        }

        public static void ExampleGetting()
        {
            var dict = new Dictionary<string, string>();

            const string key = "mySecretKey";
            dict.Add(key, "mySecretvalue");

            var values = new List<string>();
            var valuesUsingOut = new List<string>();

            values.Add(OutVariables.GetDictionaryValue(dict, key));
            values.Add(OutVariables.GetDictionaryValue(dict, "notExistingKey"));

            valuesUsingOut.Add(OutVariables.GetDictionaryValueUsingOut(dict, key));
            valuesUsingOut.Add(OutVariables.GetDictionaryValueUsingOut(dict, "notExistingKey"));

            Log(values);
            Console.WriteLine($"=== NOW USING OUT ===");
            Log(valuesUsingOut);
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

            var minDouble = Double.MinValue.ToString();
            var maxDouble = Double.MaxValue.ToString();

            ParseToDouble(minDouble);
            ParseToDouble(maxDouble);
            Console.WriteLine($"=== NOW USING OUT ===");
            ParseToDoubleUsingOut(minDouble);
            ParseToDoubleUsingOut(maxDouble);
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