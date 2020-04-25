using System;

namespace NewsCSharp
{
    public static class Ref2Semantics
    {
        public static void ExampleSemantics()
        {
            var refSemantics = new RefSemantics();
            refSemantics.SumAreasWithReadonlyStruct(refSemantics.Rectangle, refSemantics.Rectangle);

            refSemantics.SumAreasWithStruct(refSemantics.Rectangle, refSemantics.Rectangle);
            Console.WriteLine($"After SumAreasWithStruct A: {refSemantics.Rectangle.A} and B: {refSemantics.Rectangle.B}");

            refSemantics.SumAreasWithClass(refSemantics.RectangleClass, refSemantics.RectangleClass);
            Console.WriteLine($"After SumAreasWithStruct SumAreasWithClass A: {refSemantics.RectangleClass.A} and B: {refSemantics.RectangleClass.B}");
        }


    }

    public class RefSemantics
    {
        public long SumAreasWithReadonlyStruct(in Rectangle rect1, in Rectangle rect2)
        {
            // NOT ALLOWED!         
            // rect1.A = 5;
            // rect1.B = 5;
            // rect2.A = 5;
            // rect2.B = 5;
            var sum = rect1.Area + rect2.Area;
            Console.WriteLine("SumAreas: two rectangles areas equals {0}", sum);
            return sum;
        }

        public long SumAreasWithStruct(Rectangle rect1, Rectangle rect2)
        {
            rect1.A = 5;
            rect1.B = 5;
            rect2.A = 3;
            rect2.B = 3;
            var sum = rect1.Area + rect2.Area;
            Console.WriteLine("SumAreas: two rectangles areas equals {0}", sum);
            return sum;
        }

        public long SumAreasWithClass(RectangleClass rect1, RectangleClass rect2)
        {
            rect1.A = 5;
            rect1.B = 5;
            rect2.A = 3;
            rect2.B = 3;
            var sum = rect1.Area + rect2.Area;
            Console.WriteLine("SumAreas: two rectangles areas equals {0}", sum);
            return sum;
        }

        private Rectangle _rectangle = new Rectangle(10, 10);
        public ref readonly Rectangle Rectangle => ref _rectangle;


        private RectangleClass _rectangleClass = new RectangleClass(10, 10);
        public ref readonly RectangleClass RectangleClass => ref _rectangleClass;
    }

    public struct Rectangle
    {
        public Rectangle(long a, long b)
        {
            A = a;
            B = b;
        }

        public long A { get; set; }
        public long B { get; set; }
        public long Area { get => A * B; }
    }
    public class RectangleClass
    {
        public RectangleClass(long a, long b)
        {
            A = a;
            B = b;
        }

        public long A { get; set; }
        public long B { get; set; }
        public long Area { get => A * B; }
    }
}