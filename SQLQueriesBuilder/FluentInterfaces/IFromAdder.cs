namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface IFromAdder<T>
    {
        T From(string originator);
    }
}