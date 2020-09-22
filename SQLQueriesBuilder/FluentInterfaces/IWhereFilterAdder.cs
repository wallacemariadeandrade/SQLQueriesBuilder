using SQLQueriesBuilder.Builder;

namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IWhereFilterAdder<T>
    {
        T Where(string param, ColumnTypes type, string matchValue);
    }
}