using BenchmarkDotNet.Attributes;
using Benchmarking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.Shared.Benchmarks
{
    public class EvalBenchmarks
    {
        private IEnumerable<EnumWithSmallValues> _smallValueEnums;
        private IEnumerable<EnumWithLargeValues> _largeValueEnums;
        private IEnumerable<EnumWithVeryLargeValues> _veryLargeValueEnums;

        public EvalBenchmarks()
        {
            _smallValueEnums = GetEnumValues<EnumWithSmallValues>(10000).ToList();
            _largeValueEnums = GetEnumValues<EnumWithLargeValues>(10000).ToList();
            _veryLargeValueEnums = GetEnumValues<EnumWithVeryLargeValues>(10000).ToList();
        }

        private IEnumerable<T> GetEnumValues<T>(int count) where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            var indices = new[] { 0, enumValues.Length - 1, 1, enumValues.Length - 2, enumValues.Length / 2 };
            int returned = 0;
            int index = 0;
            while (returned < count)
            {
                yield return enumValues[indices[index]];
                returned++;
                index = index + 1 >= indices.Length ? 0 : index + 1;
            }
        }

        private void MultiExecution(Func<List<string>> action)
        {
            long listLength = 0;
            for (int i = 0; i < 100; i++)
            {
                var list = action();
                listLength += list.Count;
            }
        }

        [Benchmark]
        public void Switch_EnumLargeValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _largeValueEnums)
                {
                    switch (val)
                    {
                        case EnumWithLargeValues.None:
                            results.Add("Str-None"); break;
                        case EnumWithLargeValues.Value1:
                            results.Add("Str-Value1"); break;
                        case EnumWithLargeValues.Value2:
                            results.Add("Str-Value2"); break;
                        case EnumWithLargeValues.Value3:
                            results.Add("Str-Value3"); break;
                        case EnumWithLargeValues.Value4:
                            results.Add("Str-Value4"); break;
                        case EnumWithLargeValues.Value5:
                            results.Add("Str-Value5"); break;
                        case EnumWithLargeValues.Value6:
                            results.Add("Str-Value6"); break;
                        case EnumWithLargeValues.Value7:
                            results.Add("Str-Value7"); break;
                        case EnumWithLargeValues.Value8:
                            results.Add("Str-Value8"); break;
                        case EnumWithLargeValues.Value9:
                            results.Add("Str-Value9"); break;
                        default:
                            results.Add("Str-Default"); break;
                    }
                }

                return results;
            });
        }

        [Benchmark]
        public void Switch_EnumVeryLargeValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _veryLargeValueEnums)
                {
                    switch (val)
                    {
                        case EnumWithVeryLargeValues.None:
                            results.Add("Str-None"); break;
                        case EnumWithVeryLargeValues.Value1:
                            results.Add("Str-Value1"); break;
                        case EnumWithVeryLargeValues.Value2:
                            results.Add("Str-Value2"); break;
                        case EnumWithVeryLargeValues.Value3:
                            results.Add("Str-Value3"); break;
                        case EnumWithVeryLargeValues.Value4:
                            results.Add("Str-Value4"); break;
                        case EnumWithVeryLargeValues.Value5:
                            results.Add("Str-Value5"); break;
                        case EnumWithVeryLargeValues.Value6:
                            results.Add("Str-Value6"); break;
                        case EnumWithVeryLargeValues.Value7:
                            results.Add("Str-Value7"); break;
                        case EnumWithVeryLargeValues.Value8:
                            results.Add("Str-Value8"); break;
                        case EnumWithVeryLargeValues.Value9:
                            results.Add("Str-Value9"); break;
                        default:
                            results.Add("Str-Default"); break;
                    }
                }

                return results;
            });
        }

        [Benchmark]
        public void Switch_EnumSmallValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _smallValueEnums)
                {
                    switch (val)
                    {
                        case EnumWithSmallValues.None:
                            results.Add("Str-None"); break;
                        case EnumWithSmallValues.Value1:
                            results.Add("Str-Value1"); break;
                        case EnumWithSmallValues.Value2:
                            results.Add("Str-Value2"); break;
                        case EnumWithSmallValues.Value3:
                            results.Add("Str-Value3"); break;
                        case EnumWithSmallValues.Value4:
                            results.Add("Str-Value4"); break;
                        case EnumWithSmallValues.Value5:
                            results.Add("Str-Value5"); break;
                        case EnumWithSmallValues.Value6:
                            results.Add("Str-Value6"); break;
                        case EnumWithSmallValues.Value7:
                            results.Add("Str-Value7"); break;
                        case EnumWithSmallValues.Value8:
                            results.Add("Str-Value8"); break;
                        case EnumWithSmallValues.Value9:
                            results.Add("Str-Value9"); break;
                        default:
                            results.Add("Str-Default"); break;
                    }
                }

                return results;
            });
        }

        [Benchmark]
        public void If_EnumSmallValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _smallValueEnums)
                {
                    if(val == EnumWithSmallValues.None) results.Add("Str-None");
                    else if (val == EnumWithSmallValues.Value1) results.Add("Str-Value1");
                    else if (val == EnumWithSmallValues.Value2) results.Add("Str-Value2");
                    else if (val == EnumWithSmallValues.Value3) results.Add("Str-Value3");
                    else if (val == EnumWithSmallValues.Value4) results.Add("Str-Value4");
                    else if (val == EnumWithSmallValues.Value5) results.Add("Str-Value5");
                    else if (val == EnumWithSmallValues.Value6) results.Add("Str-Value6");
                    else if (val == EnumWithSmallValues.Value7) results.Add("Str-Value7");
                    else if (val == EnumWithSmallValues.Value8) results.Add("Str-Value8");
                    else if (val == EnumWithSmallValues.Value9) results.Add("Str-Value9");
                    else results.Add("Str-Default");
                }

                return results;
            });
        }

        [Benchmark]
        public void If_EnumLargeValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _largeValueEnums)
                {
                    if (val == EnumWithLargeValues.None) results.Add("Str-None");
                    else if (val == EnumWithLargeValues.Value1) results.Add("Str-Value1");
                    else if (val == EnumWithLargeValues.Value2) results.Add("Str-Value2");
                    else if (val == EnumWithLargeValues.Value3) results.Add("Str-Value3");
                    else if (val == EnumWithLargeValues.Value4) results.Add("Str-Value4");
                    else if (val == EnumWithLargeValues.Value5) results.Add("Str-Value5");
                    else if (val == EnumWithLargeValues.Value6) results.Add("Str-Value6");
                    else if (val == EnumWithLargeValues.Value7) results.Add("Str-Value7");
                    else if (val == EnumWithLargeValues.Value8) results.Add("Str-Value8");
                    else if (val == EnumWithLargeValues.Value9) results.Add("Str-Value9");
                    else results.Add("Str-Default");
                }

                return results;
            });
        }

        [Benchmark]
        public void If_EnumVeryLargeValues()
        {
            MultiExecution(() =>
            {
                var results = new List<string>();
                foreach (var val in _veryLargeValueEnums)
                {
                    if (val == EnumWithVeryLargeValues.None) results.Add("Str-None");
                    else if (val == EnumWithVeryLargeValues.Value1) results.Add("Str-Value1");
                    else if (val == EnumWithVeryLargeValues.Value2) results.Add("Str-Value2");
                    else if (val == EnumWithVeryLargeValues.Value3) results.Add("Str-Value3");
                    else if (val == EnumWithVeryLargeValues.Value4) results.Add("Str-Value4");
                    else if (val == EnumWithVeryLargeValues.Value5) results.Add("Str-Value5");
                    else if (val == EnumWithVeryLargeValues.Value6) results.Add("Str-Value6");
                    else if (val == EnumWithVeryLargeValues.Value7) results.Add("Str-Value7");
                    else if (val == EnumWithVeryLargeValues.Value8) results.Add("Str-Value8");
                    else if (val == EnumWithVeryLargeValues.Value9) results.Add("Str-Value9");
                    else results.Add("Str-Default");
                }

                return results;
            });
        }
    }
}
