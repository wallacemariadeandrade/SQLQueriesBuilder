using SQLQueriesBuilder.Builder;

namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface ITypesAdder<T>
    {
        T As(params ColumnTypes[] types);
    }
}