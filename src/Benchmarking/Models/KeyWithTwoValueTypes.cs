namespace Benchmarking.Models
{
    public struct KeyWithTwoValueTypes
    {
        public KeyWithTwoValueTypes(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public int Value1 { get; set; }

        public int Value2 { get; set; }
    }
}
