namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IColumnsAdder<T>
    {
        T AtColumns(params string[] columns);
    }
}