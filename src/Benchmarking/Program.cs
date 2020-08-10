using BenchmarkDotNet.Running;
using Benchmarking.Benchmarks;
using System;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);

            Console.ReadLine();
        }
    }
}
