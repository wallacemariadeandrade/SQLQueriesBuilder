using System.Collections.Generic;
using System.Linq;

namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        public partial class EntityHolder
        {
            public partial class ValuesHolder
            {
                internal ColumnsHolder _columns;
                internal EntityHolder _entity;
                internal IEnumerable<string> _valuesToInsert;
                
                internal ValuesHolder(EntityHolder entity, params string[] valuesToInsert)
                {
                    _entity = entity;
                    _valuesToInsert = valuesToInsert.AsEnumerable();
                }

                internal ValuesHolder(EntityHolder entity, ColumnsHolder columns, params string[] valuesToInsert)
                    : this(entity, valuesToInsert)
                {
                    _columns = columns;
                }

                public TypesHolder As(params ColumnTypes[] types) => new TypesHolder(this, types);
            }
        }
    }
}