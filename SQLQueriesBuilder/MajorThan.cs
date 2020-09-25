namespace SQLQueriesBuilder
{
    public class MajorThan : ITextualCondition
    {
        private double _value;
        public MajorThan(double value)
        {
            _value = value;
        }
        public string OperatorAsText => $">";

        public string ValueAsText => _value.ToString();
    }
}