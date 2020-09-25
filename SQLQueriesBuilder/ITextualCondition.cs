namespace SQLQueriesBuilder
{
    public interface ITextualCondition
    {
        string OperatorAsText { get; }
        string ValueAsText { get; }
    }
}