using System;
using System.Collections.Generic;
using System.Linq;
using SQLQueriesBuilder.FluentInterfaces;

namespace SQLQueriesBuilder.Builder
{
    public static partial class SQLInsertBuilder
    {
        internal class InsertBuilder 
        : IBuilder, IValuesAdder<ITypesAdderWithColumns<IBuilder>>, ITypesAdderWithColumns<IBuilder>
        {
            private string _tableName;
            private IEnumerable<DataType> _types;
            private IEnumerable<string> _columns;
            private IEnumerable<string> _values;

            internal InsertBuilder(string tableName)
            {
                _tableName = tableName;
            }

            public IBuilder As(params DataType[] types)
            {
                _types = types.AsEnumerable();
                return this;
            }

            public ITypesAdder<IBuilder> AtColumns(params string[] columns)
            {
                _columns = columns.AsEnumerable();
                return this;
            }

            public string Build()
                => _columns != null ? $"INSERT INTO {_tableName} ({string.Join(", ", _columns)}) VALUES ({string.Join(", ", UpdateValuesToHaveSingleQuotesOnTextTypes())})"
                    : $"INSERT INTO {_tableName} VALUES ({string.Join(", ", UpdateValuesToHaveSingleQuotesOnTextTypes())})";
            private IEnumerable<string> UpdateValuesToHaveSingleQuotesOnTextTypes()
            {
                ValidateArguments();
                for(int i=0; i < _values.Count(); i++)
                     yield return _types.ElementAt(i) == DataType.NonText ? _values.ElementAt(i) : $"'{_values.ElementAt(i)}'";
            }

            public ITypesAdderWithColumns<IBuilder> Values(params string[] values)
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