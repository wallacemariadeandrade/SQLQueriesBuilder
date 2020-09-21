namespace SQLQueriesHelper
{
    public interface IValuesAdder<T>
    {
        T Values(params string[] values);
    }
}