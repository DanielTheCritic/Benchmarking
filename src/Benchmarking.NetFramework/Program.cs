using BenchmarkDotNet.Environments;
using Benchmarking.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking.NetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkLauncher launcher = new BenchmarkLauncher(ClrRuntime.Net471);
            launcher.Run();

            Console.ReadLine();
        }
    }
}
