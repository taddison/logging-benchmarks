using System;
using BenchmarkDotNet.Running;

namespace logging_benchmarks
{
  class Program
  {
    static void Main(string[] args)
    {
      //RunFileWritesAndCleanup();
      BenchmarkRunner.Run<FileWrites>();
    }

    static void RunFileWritesAndCleanup()
    {
      using (var fw = new FileWrites() { Repeats = 1 })
      {
        fw.WriteToNewFile();
        fw.WriteToOpenFile();
      }
      using var cleanup = new FileWrites();
    }
  }
}
