namespace SQLQueriesHelper
{
    public interface ITypesAdder<T>
    {
        T As(params ColumnTypes[] types);
    }
}