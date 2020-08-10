namespace Benchmarking.Shared.Models
{
    public struct KeyWithTwoValueTypesAndEquals
    {
        public KeyWithTwoValueTypesAndEquals(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public override bool Equals(object obj)
        {
            var val = (KeyWithTwoValueTypesAndEquals)obj;
            return Value1 == val.Value1 && Value2 == val.Value2;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(KeyWithTwoValueTypesAndEquals left, KeyWithTwoValueTypesAndEquals right)
        {
            return left.Value1 == right.Value1 && left.Value2 == right.Value2;
        }

        public static bool operator !=(KeyWithTwoValueTypesAndEquals left, KeyWithTwoValueTypesAndEquals right)
        {
            return left.Value1 != right.Value1 || left.Value2 != right.Value2;
        }
    }
}
