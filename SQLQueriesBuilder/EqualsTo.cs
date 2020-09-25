namespace SQLQueriesBuilder
{
    public class EqualsTo : ITextualCondition
    {
        private double _to;

        public EqualsTo(double to)
        {
            _to = to;
        }

        public string OperatorAsText => $"=";

        public string ValueAsText => _to.ToString();
    }
}