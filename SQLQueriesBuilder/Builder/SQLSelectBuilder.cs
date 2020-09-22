using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static class SQLSelectBuilder
    {
        public static IWhereFilterWithBuilder<IBuilder> SelectAllFrom(string tableName) => new SimpleSelectWrapper(tableName);
        public static IFromAdder<IBuilder> Select(params string[] columns) 
            => new ComplexSelectWrapper(columns);

        internal class ComplexSelectWrapper 
            : IBuilder, IFromAdder<IBuilder>
        {
            private IEnumerable<string> _columns;
            private string _tableName;
            internal ComplexSelectWrapper(params string[] columns)
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

        internal class SimpleSelectWrapper : IWhereFilterWithBuilder<IBuilder>
        {
            private string _tableName;
            private ITextualCondition _toCondition;
            private string _comparing;
            internal SimpleSelectWrapper(string tableName)
            {
                _tableName = tableName;
            }
            public string Build()
                => _toCondition == null ? $"SELECT * FROM {_tableName}" : $"SELECT * FROM {_tableName} WHERE {_comparing} {_toCondition.GetCondition}";

            public IBuilder Where(string comparing, ITextualCondition toCondition)
            {
                _comparing = comparing;
                _toCondition = toCondition;
                return this;
            }
        }
    }
}