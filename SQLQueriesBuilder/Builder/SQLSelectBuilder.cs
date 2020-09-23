using System;
using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static class SQLSelectBuilder
    {
        public static IWhereFilterWithBuilder<IAndFilter<IBuilder>> SelectAllFrom(string tableName) => new SimpleSelectWrapper(tableName);
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

        internal class SimpleSelectWrapper : IWhereFilterWithBuilder<IAndFilter<IBuilder>>, IAndFilter<IBuilder> //IWhereFilterWithBuilder<IBuilder>
        {
            private string _tableName;
            private List<Tuple<string, ITextualCondition>> _comparingTo;
            internal SimpleSelectWrapper(string tableName)
            {
                _tableName = tableName;
            }

            public IAndFilter<IBuilder> And(string comparing, ITextualCondition toCondition)
            {
                _comparingTo.Add(new Tuple<string, ITextualCondition>(comparing, toCondition));
                return this;
            }

            public string Build()
            {
                if(_comparingTo == null) return $"SELECT * FROM {_tableName}";
                var conditions = string.Join(" AND ", _comparingTo.Select(x => $"{x.Item1} {x.Item2.GetCondition}")); // AA > B and C > d and D = F and AA < F
                return $"SELECT * FROM {_tableName} WHERE {conditions}";
            }
            //_toCondition == null ? $"SELECT * FROM {_tableName}" : $"SELECT * FROM {_tableName} WHERE {_comparing} {_toCondition.GetCondition}";

            IAndFilter<IBuilder> IWhereFilter<IAndFilter<IBuilder>>.Where(string comparing, ITextualCondition toCondition)
            {
                _comparingTo = new List<Tuple<string, ITextualCondition>> {
                    new Tuple<string, ITextualCondition>(comparing, toCondition)
                };
                return this;
            }
        }
    }
}