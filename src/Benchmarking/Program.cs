using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Benchmarking.Shared;
using Benchmarking.Shared.Benchmarks;
using System;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkLauncher launcher = new BenchmarkLauncher(CoreRuntime.Core21);
            launcher.Run();

            Console.ReadLine();
        }
    }
}
