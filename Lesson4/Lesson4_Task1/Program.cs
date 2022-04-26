using System;
using BenchmarkDotNet.Running;

namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Console.ReadKey();
        }
    }
}
