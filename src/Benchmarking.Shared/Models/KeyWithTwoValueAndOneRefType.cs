namespace Benchmarking.Shared.Models
{
    public struct KeyWithTwoValueAndOneRefType
    {
        public KeyWithTwoValueAndOneRefType(int value1, int value2, string stringValue)
        {
            Value1 = value1;
            Value2 = value2;
            StringValue = stringValue;
        }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public string StringValue { get; set; }
    }
}
