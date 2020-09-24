using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static partial class SQLSelectBuilder
    {
        public static IWhereFilterWithBuilder<IAndFilter<IBuilder>> SelectAllFrom(string tableName) => new SelectAllBuilder(tableName);
        public static IFromAdder<IBuilder> Select(params string[] columns) 
            => new SelectBuilder(columns);
    }
}