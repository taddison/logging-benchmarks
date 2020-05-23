``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.836 (1909/November2018Update/19H2)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.102
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|          Method | Repeats |              Mean |             Error |             StdDev |
|---------------- |-------- |------------------:|------------------:|-------------------:|
| **WriteToOpenFile** |       **1** |          **52.95 ns** |          **1.016 ns** |           **0.951 ns** |
|  WriteToNewFile |       1 |     509,104.14 ns |     36,205.902 ns |     105,614.315 ns |
| **WriteToOpenFile** |     **100** |       **5,843.32 ns** |        **114.333 ns** |         **163.973 ns** |
|  WriteToNewFile |     100 |  46,641,499.30 ns |  1,159,925.460 ns |   3,155,662.759 ns |
| **WriteToOpenFile** |    **1000** |      **65,722.28 ns** |      **2,646.466 ns** |       **7,761.627 ns** |
|  WriteToNewFile |    1000 | 696,956,126.00 ns | 42,381,320.593 ns | 124,962,279.990 ns |
