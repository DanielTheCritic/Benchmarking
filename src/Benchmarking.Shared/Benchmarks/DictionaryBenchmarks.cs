using BenchmarkDotNet.Attributes;
using Benchmarking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.Shared.Benchmarks
{
    public class DictionaryBenchmarks
    {
        private readonly Dictionary<string, TestObject> _stringAsTwoKeyValues;
        private readonly Dictionary<string, TestObject> _stringAsThreeKeyValues;
        private readonly Dictionary<int, TestObject> _intKeyValues;
        private readonly Dictionary<KeyWithTwoValueAndOneRefType, TestObject> _twoValueAndOneRefTypeKeyValues;
        private readonly Dictionary<KeyWithTwoValueTypes, TestObject> _twoValueTypesKeyValues;
        private readonly Dictionary<KeyWithThreeValueTypes, TestObject> _threeValueTypesKeyValues;
        private readonly Dictionary<KeyWithTwoValueTypesAndEquals, TestObject> _twoValueTypesAndEqualsValues;
        private readonly IEnumerable<TestObject> _indices;

        public DictionaryBenchmarks()
        {
            _stringAsTwoKeyValues = new Dictionary<string, TestObject>();
            _stringAsThreeKeyValues = new Dictionary<string, TestObject>();
            _intKeyValues = new Dictionary<int, TestObject>();
            _twoValueTypesKeyValues = new Dictionary<KeyWithTwoValueTypes, TestObject>();
            _twoValueAndOneRefTypeKeyValues = new Dictionary<KeyWithTwoValueAndOneRefType, TestObject>();
            _threeValueTypesKeyValues = new Dictionary<KeyWithThreeValueTypes, TestObject>();
            _twoValueTypesAndEqualsValues = new Dictionary<KeyWithTwoValueTypesAndEquals, TestObject>();

            var testObjects = GenerateUniqueTestObjects(10000);
            _indices = GetAccessibleIndices(testObjects);
            foreach (var testObject in testObjects)
            {
                _stringAsTwoKeyValues.Add($"{testObject.IntValue1}|{testObject.IntValue2}", testObject);
                _stringAsThreeKeyValues.Add($"{testObject.IntValue1}|{testObject.IntValue2}|{testObject.FloatValue}", testObject);
                _intKeyValues.Add(testObject.IntValue1, testObject);
                _twoValueTypesKeyValues.Add(new KeyWithTwoValueTypes(testObject.IntValue1, testObject.IntValue2), testObject);
                _twoValueAndOneRefTypeKeyValues.Add(new KeyWithTwoValueAndOneRefType(testObject.IntValue1, testObject.IntValue2, testObject.FloatValue.ToString()), testObject);
                _threeValueTypesKeyValues.Add(new KeyWithThreeValueTypes(testObject.IntValue1, testObject.IntValue2, testObject.FloatValue), testObject);
                _twoValueTypesAndEqualsValues.Add(new KeyWithTwoValueTypesAndEquals(testObject.IntValue1, testObject.IntValue2), testObject);
            }
        } 

        private IEnumerable<TestObject> GetAccessibleIndices(IEnumerable<TestObject> objects)
        {
            Random random = new Random();
            var count = objects.Count();

            var indices = new List<int> { 0, count - 1, count - 10, count - 100, count - 1000, count / 5, count / 65, count / 49, count / 2, count - 2, 2, 5, 10, 49, 65, 100, 998, 999, 1000, 1001 };
            return indices.Select(index => objects.ElementAt(index));
        }

        private IEnumerable<TestObject> GenerateUniqueTestObjects(int count)
        {
            return Enumerable.Range(0, count).Select(r => new TestObject
            {
                IntValue1 = r,
                IntValue2 = r * 1000,
                FloatValue = r * 0.1f,
                StringValue = r.ToString()
            });
        }

        private void MultiExecution(Func<IEnumerable<TestObject>> action)
        {
            int counter = 0;
            for (int i = 0; i < 100; i++)
            {
                var values = action();
                counter += values.Count();
            }
        }

        [Benchmark]
        public void Dictionary_IntKey()
        {
            MultiExecution(() => _indices.Select(index => _intKeyValues[index.IntValue1]));
        }

        [Benchmark]
        public void Dictionary_StringAsTwoValueKey()
        {
            MultiExecution(() => _indices.Select(i => _stringAsTwoKeyValues[$"{i.IntValue1}|{i.IntValue2}"]));
        }

        [Benchmark]
        public void Dictionary_StringAsThreeValueKey()
        {
            MultiExecution(() => _indices.Select(i => _stringAsThreeKeyValues[$"{i.IntValue1}|{i.IntValue2}|{i.FloatValue}"]));
        }

        [Benchmark]
        public void Dictionary_TwoValueTypeKey()
        {
            MultiExecution(() => _indices.Select(i => _twoValueTypesKeyValues[new KeyWithTwoValueTypes(i.IntValue1, i.IntValue2)]));
        }

        [Benchmark]
        public void Dictionary_TwoValueAndOneRefTypeKey()
        {
            MultiExecution(() => _indices.Select(i => _twoValueAndOneRefTypeKeyValues[new KeyWithTwoValueAndOneRefType(i.IntValue1, i.IntValue2, i.FloatValue.ToString())]));
        }

        [Benchmark]
        public void Dictionary_ThreeValueTypeKey()
        {
            MultiExecution(() => _indices.Select(i => _threeValueTypesKeyValues[new KeyWithThreeValueTypes(i.IntValue1, i.IntValue2, i.FloatValue)]));
        }

        [Benchmark]
        public void Dictionary_TwoValueTypeAndEqualsKey()
        {
            MultiExecution(() => _indices.Select(i => _twoValueTypesAndEqualsValues[new KeyWithTwoValueTypesAndEquals(i.IntValue1, i.IntValue2)]));
        }
    }
}
