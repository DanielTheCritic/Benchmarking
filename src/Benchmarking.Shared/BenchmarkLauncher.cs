using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Benchmarking.Shared.Benchmarks;
using System;

namespace Benchmarking.Shared
{
    public class BenchmarkLauncher
    {
        private readonly Runtime _runtime;

        public BenchmarkLauncher(Runtime runtime)
        {
            _runtime = runtime;
        }

        public void Run()
        {
            bool hasErrors = true;
            try
            {
                new EvalBenchmarks();
                new StringBenchmarks();
                new DictionaryBenchmarks();
                hasErrors = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred while trying to initialize the Benchmarks:\n{exception}");
            }

            if (!hasErrors)
            {
                var config = DefaultConfig.Instance;
                config.AddJob(Job.Default.WithRuntime(_runtime));
                //  BenchmarkRunner.Run<DictionaryBenchmarks>();
                BenchmarkRunner.Run<EvalBenchmarks>(config);
                //   BenchmarkRunner.Run<StringBenchmarks>();
            }
        }
    }
}
