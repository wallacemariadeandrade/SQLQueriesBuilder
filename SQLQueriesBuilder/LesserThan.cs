namespace SQLQueriesBuilder
{
    public class LesserThan : ITextualCondition
    {
        private double _to;

        public LesserThan(double to)
        {
            _to = to;
        }

        public string OperatorAsText => "<";

        public string ValueAsText => _to.ToString();
    }
}