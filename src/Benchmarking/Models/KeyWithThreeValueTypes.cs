namespace Benchmarking.Models
{
    public struct KeyWithThreeValueTypes
    {
        public KeyWithThreeValueTypes(int value1, int value2, float value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public float Value3 { get; set; }
    }
}
