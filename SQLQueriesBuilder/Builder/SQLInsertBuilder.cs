using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static partial class SQLInsertBuilder   
    {
        public static IValuesAdder<ITypesAdderWithColumns<IBuilder>> InsertAt(string tableName)
            => new InsertBuilder(tableName);
        
    }
}