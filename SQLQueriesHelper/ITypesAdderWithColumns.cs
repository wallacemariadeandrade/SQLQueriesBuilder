namespace SQLQueriesHelper
{
    public interface ITypesAdderWithColumns<T> : ITypesAdder<T>, IColumnsAdder<ITypesAdder<T>> {}
}