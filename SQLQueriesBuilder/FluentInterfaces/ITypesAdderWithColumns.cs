namespace SQLQueriesBuilder.FluentInterfaces
{
    public interface ITypesAdderWithColumns<T> : ITypesAdder<T>, IColumnsAdder<ITypesAdder<T>> {}
}