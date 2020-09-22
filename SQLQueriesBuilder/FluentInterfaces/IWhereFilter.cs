namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IWhereFilter<T>
    {
        T Where(string comparing, ITextualCondition toCondition);
    }
}