using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static partial class SQLSelectBuilder
    {
        internal class SelectBuilder 
            : IBuilder, IFromAdder<IBuilder>
        {
            private IEnumerable<string> _columns;
            private string _tableName;
            internal SelectBuilder(params string[] columns)
            {
                _columns = columns.AsEnumerable();
            }

            public string Build() => $"SELECT {string.Join(", ", _columns)} FROM {_tableName}";

            public IBuilder From(string tableName)
            {
                _tableName = tableName;
                return this;
            }
        }
    }
}