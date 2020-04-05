using System;
using System.Collections;
using System.Globalization;

namespace NewsCSharp
{
    public static class Discord
    {

        public static bool IsANumber(dynamic var)
        {
            bool res = double.TryParse(var, out double _);
            if (res)
            {
                Console.WriteLine($"{var} is a number");
            }
            else
            {
                Console.WriteLine($"{var} is not a number!");
            }
            return res;
        }

        public static void ExampleIsANumber()
        {
            var values = new ArrayList();
            values.Add("a");
            values.Add("1a");
            values.Add("1.1");
            values.Add("1,2");
            values.Add($"1{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}23");

            foreach (var val in values)
            {
                IsANumber(val);
            }
        }
    }
}