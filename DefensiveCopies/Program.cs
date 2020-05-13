using System;

namespace StructVersusClass {

    class Program {

        private static Point _p1 = new Point(3, 4);
        private static readonly Point _p2 = new Point(3, 4);

        static void Main(string[] args) {
            Console.WriteLine(_p1.ToString()); // (3,4)
            Console.WriteLine(_p1.Distance);   // 5
            Console.WriteLine();

            _p2.Swap(); // Defensive Copy, the copy is swapped
            Console.WriteLine(_p2.ToString()); // (3,4)
            Console.WriteLine(_p2.Distance);   // 5
            Console.WriteLine();

            Point p3 = _p1; // Value copy

            p3.Swap();
            //p3 = p3.Swap();

            Console.WriteLine(p3.ToString());  // (4,3)
            Console.WriteLine(p3.Distance);    // 5
            Console.WriteLine();

            ref readonly Point p4 = ref _p1;
            p4.Swap(); // Defensive Copy, the copy is swapped
            Console.WriteLine(p4.ToString()); // (3,4)
            Console.WriteLine(p4.Distance);   // 5
            Console.WriteLine();

            Foo(_p1); // (3,4) & 5
        }

        static void Foo(in Point p) {
            p.Swap(); // Defensive Copy, the copy is swapped
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.Distance);
        }
    }


    struct Point {

        public double X, Y;

        public readonly void Foo() {
            X = 12;
            Swap();
        }

        public void Swap() => this = new Point(Y, X);

        //public readonly Point Swap() => new Point(Y, X);

        public Point(double x, double y) { X = x; Y = y; }


        public readonly double Distance => Math.Sqrt((X * X) + (Y * Y));

        public readonly override string ToString() => $"({X.ToString()},{Y.ToString()})";


    }

}
