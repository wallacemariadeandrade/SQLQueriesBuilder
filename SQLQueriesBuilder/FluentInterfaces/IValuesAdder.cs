namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IValuesAdder<T>
    {
        T Values(params string[] values);
    }
}