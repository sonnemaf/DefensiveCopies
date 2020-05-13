using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;

namespace Benchmark {

    class Program {

        static void Main(string[] args) {
            // Install-Package BenchmarkDotNet 
            BenchmarkRunner.Run<DateTimeBM>();

            //BenchmarkRunner.Run<PointBM>();
        }
    }

    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    public class DateTimeBM {

        private DateTime _date1;
        private readonly DateTime _date2;

        [Benchmark] public int NotReadonly() => _date1.Year;

        [Benchmark] public int Readonly() => _date2.Year;
    }


    public class PointBM {

        private readonly Point3D _p1;

        [Benchmark]
        public void NotReadonly() {
            for (int i = 0; i < 100; i++) {
                _p1.Foo();
            }
        }

        [Benchmark(Baseline = true)]
        public void Readonly() {
            for (int i = 0; i < 100; i++) {
                _p1.Bar();
            }
        }
    }



    struct Point3D {

        public double X;
        public double Y;
        public double Z;

        public double Foo() => X + 1;
        public readonly double Bar() => X + 1;
    }
}
