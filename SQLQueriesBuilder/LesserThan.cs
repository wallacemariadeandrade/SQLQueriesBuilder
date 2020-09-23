namespace SQLQueriesBuilder
{
    public class LesserThan : ITextualCondition
    {
        private double _to;

        public LesserThan(double to)
        {
            _to = to;
        }

        public string GetCondition => $"< {_to}";
    }
}