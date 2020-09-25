using System;
using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static partial class SQLSelectBuilder
    {
        internal class SelectBuilder 
            : IFromAdder<IWhereFilterWithBuilder<IAndFilter<IBuilder>>>, 
                IWhereFilterWithBuilder<IAndFilter<IBuilder>>, IAndFilter<IBuilder>
        {
            private IEnumerable<string> _columns;
            private string _tableName;
            private List<Tuple<string, ITextualCondition>> _comparingTo;
            internal SelectBuilder(params string[] columns)
            {
                _columns = columns.AsEnumerable();
            }

            public IAndFilter<IBuilder> And(string comparing, ITextualCondition toCondition)
            {
                _comparingTo.Add(new Tuple<string, ITextualCondition>(
                    comparing, toCondition
                ));
                return this;
            }

            public IWhereFilterWithBuilder<IAndFilter<IBuilder>> From(string tableName)
            {
                _tableName = tableName;
                return this;
            }

            IAndFilter<IBuilder> IWhereFilter<IAndFilter<IBuilder>>.Where(string comparing, ITextualCondition toCondition)
            {
                _comparingTo = new List<Tuple<string, ITextualCondition>> {
                    new Tuple<string, ITextualCondition> (
                        comparing, toCondition
                    )
                };
                return this;
            }

            public string Build() 
            {
                if (_comparingTo == null) return $"SELECT {string.Join(", ", _columns)} FROM {_tableName}";
                var conditions = string.Join(" AND ", _comparingTo.Select(x => $"{x.Item1} {x.Item2.OperatorAsText} {x.Item2.ValueAsText}")); // AA > B and C > d and D = F and AA < F
                return $"SELECT {string.Join(", ", _columns)} FROM {_tableName} WHERE {conditions}";
            }
        }
    }
}