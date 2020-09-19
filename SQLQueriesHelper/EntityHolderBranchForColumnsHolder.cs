using System.Collections.Generic;
using System.Linq;

namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        public partial class EntityHolder
        {
            public class ColumnsHolder
            {
                internal IEnumerable<string> _names;
                internal EntityHolder _entity;

                internal ColumnsHolder(EntityHolder entity, params string[] names)
                {
                    _entity = entity;
                    _names = names.AsEnumerable();
                }

                public ValuesHolder WithValues(params string[] valuesToInsert) => _entity.WithValues(this, valuesToInsert);
            }
        }
    }
}