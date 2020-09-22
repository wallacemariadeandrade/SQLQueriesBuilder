using System;
using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static class SQLInsertBuilder   
    {
        public static IValuesAdder<ITypesAdderWithColumns<Builder>> InsertAt(string tableName)
        {
            return new InsertWraper(tableName);
        }

        internal class InsertWraper 
        : Builder, IValuesAdder<ITypesAdderWithColumns<Builder>>, ITypesAdderWithColumns<Builder>
        {
            private string _tableName;
            private IEnumerable<ColumnTypes> _types;
            private IEnumerable<string> _columns;
            private IEnumerable<string> _values;

            internal InsertWraper(string tableName)
            {
                _tableName = tableName;
            }

            public Builder As(params ColumnTypes[] types)
            {
                _types = types.AsEnumerable();
                return this;
            }

            public ITypesAdder<Builder> AtColumns(params string[] columns)
            {
                _columns = columns.AsEnumerable();
                return this;
            }

            public override string Build()
            {
                ValidateArguments();
                var query = $"INSERT INTO {_tableName}";
                if(_columns != null) query += $" ({string.Join(", ", _columns)})";
                query += " VALUES (";
                for(int i=0; i < _values.Count(); i++)
                {
                    var value = _types.ElementAt(i) == ColumnTypes.NonText ? _values.ElementAt(i) : $"'{_values.ElementAt(i)}'";
                    query += $"{value}, ";
                }
                return query.Remove(query.Length - 2) + ")";
            }

            public ITypesAdderWithColumns<Builder> Values(params string[] values)
            {
                _values = values;
                return this;
            }

            private void ValidateArguments()
            {
                if(_values.Count() != _types.Count()) throw new ArgumentOutOfRangeException();
                if(_columns != null && _columns.Count() != _values.Count()) throw new ArgumentOutOfRangeException();
            }
        }
    }
}