using SQLQueriesBuilder.Builder;

namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IAndFilter<T> : IBuilder
    {
        IAndFilter<T> And(string comparing, ITextualCondition toCondition);
    }
}