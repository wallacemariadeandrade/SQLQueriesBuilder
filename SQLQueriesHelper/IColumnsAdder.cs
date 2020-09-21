namespace SQLQueriesHelper
{
    public interface IColumnsAdder<T>
    {
        T AtColumns(params string[] columns);
    }
}