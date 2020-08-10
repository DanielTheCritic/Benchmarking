# Benchmarking
Benchmarking various concepts in C# using BenchmarkDotNet.

**String Benchmarks**
Concating a different number of strings as specific in the method name.
Each execution is performed 100 times.

|                           Method |        Mean |     Error |     StdDev |
|--------------------------------- |------------:|----------:|-----------:|
|          String_Concat_2_Strings |    48.01 μs |  0.955 μs |   2.057 μs |
|          String_Concat_5_Strings |   142.88 μs |  5.046 μs |  14.479 μs |
|        String_Concat_100_Strings | 4,324.42 μs | 96.450 μs | 279.818 μs |
|   StringBuilder_Concat_2_Strings |    72.43 μs |  4.809 μs |  14.181 μs |
|   StringBuilder_Concat_5_Strings |   182.42 μs | 13.555 μs |  39.968 μs |
| StringBuilder_Concat_100_Strings | 2,629.21 μs | 86.659 μs | 248.640 μs |

**Dictionary Benchmarks**
Fetching 10 different values from dictionaries with 10000 items.
Each execution is performed 100 times.

|                              Method |       Mean |    Error |    StdDev |     Median |
|------------------------------------ |-----------:|---------:|----------:|-----------:|
|                   Dictionary_IntKey |   327.8 μs |  8.09 μs |  22.00 μs |   325.2 μs |
|      Dictionary_StringAsTwoValueKey | 1,202.9 μs | 54.36 μs | 155.96 μs | 1,178.3 μs |
|    Dictionary_StringAsThreeValueKey | 1,940.9 μs | 46.12 μs | 127.81 μs | 1,896.3 μs |
|          Dictionary_TwoValueTypeKey |   641.9 μs | 21.12 μs |  60.60 μs |   634.7 μs |
| Dictionary_TwoValueAndOneRefTypeKey | 3,264.3 μs | 64.36 μs | 169.55 μs | 3,205.4 μs |
|        Dictionary_ThreeValueTypeKey | 2,606.9 μs | 76.85 μs | 215.49 μs | 2,527.7 μs |
| Dictionary_TwoValueTypeAndEqualsKey |   595.5 μs | 14.62 μs |  41.47 μs |   580.6 μs |

**Eval Benchmarks**
Evaluating 10000 list items.
Each execution is performed 100 times.

|                     Method |     Mean |    Error |   StdDev |
|--------------------------- |---------:|---------:|---------:|
|     Switch_EnumLargeValues | 32.39 ms | 0.188 ms | 0.157 ms |
| Switch_EnumVeryLargeValues | 31.86 ms | 0.436 ms | 0.386 ms |
|     Switch_EnumSmallValues | 31.83 ms | 0.310 ms | 0.290 ms |
|         If_EnumSmallValues | 33.21 ms | 0.131 ms | 0.116 ms |
|         If_EnumLargeValues | 34.53 ms | 0.261 ms | 0.244 ms |
|     If_EnumVeryLargeValues | 33.76 ms | 0.257 ms | 0.228 ms |