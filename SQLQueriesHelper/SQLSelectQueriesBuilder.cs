using static SQLQueriesHelper.SQLQueriesBuilder.EntityHolder;

namespace SQLQueriesHelper
{
    public class SQLSelectQueriesBuilder : SQLQueriesBuilder
    {
        private EntityHolder _entity;
        private ColumnsHolder _columns;
        internal SQLSelectQueriesBuilder(EntityHolder entity)
        {
            _entity = entity;
        }

        internal SQLSelectQueriesBuilder(ColumnsHolder columns)
        {
            _columns = columns;
        }

        public static EntityHolder SelectAllFrom(string entityName) => new EntityHolder(entityName);

        public static EntityHolder SelectFrom(string entityName) => new EntityHolder(entityName);

        public override string Build()
        {
            if(_columns != null) return $"SELECT {string.Join(", ", _columns._names)} FROM {_columns._entity._name}";
            return $"SELECT * FROM {_entity._name}";
        }
    }
}