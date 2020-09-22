using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static class SQLSelectBuilder
    {
        public static Builder SelectAllFrom(string tableName) => new SimpleSelectWrapper(tableName);
        public static IFromAdder<Builder> Select(params string[] columns) 
            => new ComplexSelectWrapper(columns);

        internal class ComplexSelectWrapper 
            : Builder, IFromAdder<Builder>
        {
            private IEnumerable<string> _columns;
            private string _tableName;
            internal ComplexSelectWrapper(params string[] columns)
            {
                _columns = columns.AsEnumerable();
            }

            public override string Build() => $"SELECT {string.Join(", ", _columns)} FROM {_tableName}";

            public Builder From(string tableName)
            {
                _tableName = tableName;
                return this;
            }
        }

        internal class SimpleSelectWrapper : Builder
        {
            private string _tableName;
            internal SimpleSelectWrapper(string tableName)
            {
                _tableName = tableName;
            }
            public override string Build() => $"SELECT * FROM {_tableName}";
        }
    }
}