using System;
using System.Linq;

namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        private EntityHolder.ValuesHolder.TypesHolder _types;
        internal SQLQueriesBuilder(EntityHolder.ValuesHolder.TypesHolder typesHolder)
        {
            _types = typesHolder;
            if(_types._valuesTypes.Count() != _types._values._valuesToInsert.Count()) 
                throw new ArgumentOutOfRangeException("valuesToInsert, types", $"Number of provided values and types must be the same. It was provided {_types._values._valuesToInsert.Count()} values and {_types._valuesTypes.Count()} types.");
            if(_types._values._columns != null)
                if(_types._values._columns._names.Count() != _types._valuesTypes.Count())
                    throw new ArgumentOutOfRangeException("columnsNames", $"Number of provided columns must be the same for values and types. It was provided {_types._values._valuesToInsert.Count()} values and {_types._valuesTypes.Count()} types but {_types._values._columns._names.Count()} columns.");
        }

        public string Build()
        {
            var insertBegin = _types._values._columns == null ? $"INSERT INTO {_types._values._entity._name} VALUES (" : $"INSERT INTO {_types._values._entity._name} ({string.Join(", ", _types._values._columns._names)}) VALUES (";
            var values = "";
            for(int i =0; i < _types._valuesTypes.Count(); i++)
            {
                var valueString = _types._valuesTypes.ElementAt(i) == ColumnTypes.Text ? $"'{_types._values._valuesToInsert.ElementAt(i)}'" : _types._values._valuesToInsert.ElementAt(i);
                values += valueString + ", ";
            }            
            return insertBegin + values.Remove(values.Length-2) + ")";
        }

        public static EntityHolder InsertAt(string entityName) => new EntityHolder(entityName);
    }
}