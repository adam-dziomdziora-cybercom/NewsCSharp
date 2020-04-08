using System;

namespace NewsCSharp
{
    public static class VariableLiterals
    {

        public static bool DoesOneEqualOne()
        {
            const int trueOne = 1;

            const int one = 0b0001;

            return one == trueOne;
        }

        public static bool DoesTwoTimesFoursEqualEight()
        {
            const int trueEight = 8;

            const int two = 2;
            const int four = 0b0100;

            int eight = two * four;

            Console.WriteLine($"Eight? {eight}");
            string eightBinary = Convert.ToString(eight, 2);
            Console.WriteLine($"Eight binary? 0b'{eightBinary}'");

            return eight == trueEight;
        }

        public static bool DoesTenThousandsEqualTenThousand()
        {
            const int trueTenThousands = 10000;

            const int tenThousands = 10_000;

            return tenThousands == trueTenThousands;
        }

        public static bool DoesEighteenEqualEighteen()
        {
            const int trueEighteen = 18;

            const int eighteen = 0b00001_0010;

            return eighteen == trueEighteen;
        }



        public static void ExampleLiterals()
        {
            Console.WriteLine();
            Console.WriteLine("======= VARIABLE LITERALS =======");

            Console.WriteLine($"Does One Equal One? {DoesOneEqualOne()}");
            Console.WriteLine($"Does Two Times Fours Equal Eight? {DoesTwoTimesFoursEqualEight()}");
            Console.WriteLine($"Does Ten Thousands Equal Ten Thousands? {DoesTenThousandsEqualTenThousand()}");
            Console.WriteLine($"Does Eighteen nEqual Eighteen? {DoesEighteenEqualEighteen()}");

            Console.WriteLine("====================================================================");
        }
    }
}