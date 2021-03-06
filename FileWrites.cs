using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace logging_benchmarks
{
  public class FileWrites : IDisposable
  {
    private string _targetFolder;
    private StreamWriter _streamWriter;
    private bool disposedValue;
    const string LOG_STRING = "This is a string to log";

    public FileWrites()
    {
      var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      _targetFolder = Path.Combine(folderPath, "temp");
      if (Directory.Exists(_targetFolder))
      {
        Console.Write("Temp folder exists, deleting...");
        Directory.Delete(_targetFolder, true);
        Console.WriteLine("done");
      }
      Directory.CreateDirectory(_targetFolder);

      var fileName = Guid.NewGuid().ToString();
      var fileStream = File.OpenWrite(Path.Combine(_targetFolder, fileName));
      _streamWriter = new StreamWriter(fileStream);
    }

    [Params(1, 100, 1000)]
    public int Repeats { get; set; }

    [Benchmark]
    public void WriteToOpenFile()
    {
      for (var i = 0; i < Repeats; i++)
      {
        _streamWriter.WriteLine(LOG_STRING);
      }
    }

    [Benchmark]
    public void WriteToNewFile()
    {
      for (var i = 0; i < Repeats; i++)
      {
        File.WriteAllText(Path.Combine(_targetFolder, Guid.NewGuid().ToString()), LOG_STRING);
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _streamWriter.Close();
          _streamWriter.Dispose();
        }

        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
