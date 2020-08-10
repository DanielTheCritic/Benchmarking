using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmarking.Shared.Benchmarks
{
    public class StringBenchmarks
    {
        private IEnumerable<string> _twoStrings;
        private IEnumerable<string> _fiveStrings;
        private IEnumerable<string> _hundredStrings;

        public StringBenchmarks()
        {
            _twoStrings = GetStrings(2);
            _fiveStrings = GetStrings(5);
            _hundredStrings = GetStrings(100);
        }

        private IEnumerable<string> GetStrings(int count)
        {
            return Enumerable.Range(0, count).Select(n => $"str{n}");
        }

        private void MultiExecution(Func<string> action)
        {
            long stringLength = 0;
            for (int i = 0; i < 100; i++)
            {
                var str = action();
                stringLength += str.Length;
            }
        }

        [Benchmark]
        public void String_Concat_2_Strings()
        {
            MultiExecution(() =>
            {
                string str = "";
                foreach (var s in _twoStrings)
                {
                    str += s;
                }
                return str;
            });
        }

        [Benchmark]
        public void String_Concat_5_Strings()
        {
            MultiExecution(() =>
            {
                string str = "";
                foreach (var s in _fiveStrings)
                {
                    str += s;
                }
                return str;
            });
        }

        [Benchmark]
        public void String_Concat_100_Strings()
        {
            MultiExecution(() =>
            {
                string str = "";
                foreach (var s in _hundredStrings)
                {
                    str += s;
                }
                return str;
            });
        }

        [Benchmark]
        public void StringBuilder_Concat_2_Strings()
        {
            MultiExecution(() =>
            {
                var builder = new StringBuilder();
                foreach (var s in _twoStrings)
                {
                    builder.Append(s);
                }
                return builder.ToString();
            });
        }

        [Benchmark]
        public void StringBuilder_Concat_5_Strings()
        {
            MultiExecution(() =>
            {
                var builder = new StringBuilder();
                foreach (var s in _fiveStrings)
                {
                    builder.Append(s);
                }
                return builder.ToString();
            });
        }

        [Benchmark]
        public void StringBuilder_Concat_100_Strings()
        {
            MultiExecution(() =>
            {
                var builder = new StringBuilder();
                foreach (var s in _hundredStrings)
                {
                    builder.Append(s);
                }
                return builder.ToString();
            });
        }
    }
}
