# Benchmarking
Benchmarking various concepts in C# using DotNetBenchmarks.

**String Benchmarks**

|                           Method |        Mean |     Error |     StdDev |
|--------------------------------- |------------:|----------:|-----------:|
|          String_Concat_2_Strings |    48.01 us |  0.955 us |   2.057 us |
|          String_Concat_5_Strings |   142.88 us |  5.046 us |  14.479 us |
|        String_Concat_100_Strings | 4,324.42 us | 96.450 us | 279.818 us |
|   StringBuilder_Concat_2_Strings |    72.43 us |  4.809 us |  14.181 us |
|   StringBuilder_Concat_5_Strings |   182.42 us | 13.555 us |  39.968 us |
| StringBuilder_Concat_100_Strings | 2,629.21 us | 86.659 us | 248.640 us |

**Dictionary Benchmarks**

|                              Method |       Mean |    Error |    StdDev |     Median |
|------------------------------------ |-----------:|---------:|----------:|-----------:|
|                   Dictionary_IntKey |   327.8 us |  8.09 us |  22.00 us |   325.2 us |
|      Dictionary_StringAsTwoValueKey | 1,202.9 us | 54.36 us | 155.96 us | 1,178.3 us |
|    Dictionary_StringAsThreeValueKey | 1,940.9 us | 46.12 us | 127.81 us | 1,896.3 us |
|          Dictionary_TwoValueTypeKey |   641.9 us | 21.12 us |  60.60 us |   634.7 us |
| Dictionary_TwoValueAndOneRefTypeKey | 3,264.3 us | 64.36 us | 169.55 us | 3,205.4 us |
|        Dictionary_ThreeValueTypeKey | 2,606.9 us | 76.85 us | 215.49 us | 2,527.7 us |
| Dictionary_TwoValueTypeAndEqualsKey |   595.5 us | 14.62 us |  41.47 us |   580.6 us |