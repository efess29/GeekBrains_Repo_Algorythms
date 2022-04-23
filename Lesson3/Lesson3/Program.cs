using System;
using BenchmarkDotNet.Running;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DistanceSearchBenchmarks>();

            Console.ReadKey();
        }
    }
}
