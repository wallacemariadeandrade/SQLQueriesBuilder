using SQLQueriesBuilder.Builder;

namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IWhereFilterWithBuilder<T> : IWhereFilter<T>, IBuilder
    {
    
    }
}