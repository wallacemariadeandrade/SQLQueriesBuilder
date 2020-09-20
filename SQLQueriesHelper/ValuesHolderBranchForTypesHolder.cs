using System.Collections.Generic;

namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        public partial class EntityHolder
        {
            public partial class ValuesHolder
            {
                public class TypesHolder
                {
                    internal ValuesHolder _values;
                    internal IEnumerable<ColumnTypes> _valuesTypes;

                    internal TypesHolder(ValuesHolder values, params ColumnTypes[] types)
                    {
                        _values = values;
                        _valuesTypes = types;
                    }

                    public SQLQueriesBuilder Builder() => new SQLInsertQueriesBuilder(this);
                }
            }
        }
    }
}