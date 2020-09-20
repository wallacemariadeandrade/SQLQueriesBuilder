using System;
using System.Linq;

namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        private EntityHolder.ColumnsHolder _columns;
        private EntityHolder _entity;
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

        internal SQLQueriesBuilder(EntityHolder entity)
        {
            _entity = entity;
        }  

        internal SQLQueriesBuilder(EntityHolder.ColumnsHolder columns)
        {
            _columns = columns;
        }    

        public string Build()
        {
            if(_types != null) return BuildInsertQuery();
            return BuildSelectQuery();
        }

        public static EntityHolder InsertAt(string entityName) => new EntityHolder(entityName);

        public static EntityHolder SelectAllFrom(string entityName) => new EntityHolder(entityName);

        public static EntityHolder SelectFrom(string entityName) => new EntityHolder(entityName);

        private string BuildInsertQuery()
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

        private string BuildSelectQuery()
        {
            if(_columns != null) return $"SELECT {string.Join(", ", _columns._names)} FROM {_columns._entity._name}";
            return $"SELECT * FROM {_entity._name}";
        }
    }
}