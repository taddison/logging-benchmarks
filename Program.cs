using System;
using BenchmarkDotNet.Running;

namespace logging_benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FileWrites>();
        }
    }
}
