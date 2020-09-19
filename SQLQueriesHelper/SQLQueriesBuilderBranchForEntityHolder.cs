namespace SQLQueriesHelper
{
    public partial class SQLQueriesBuilder
    {
        public partial class EntityHolder
        {
            internal string _name;
            internal EntityHolder(string name)
            {
                _name = name;
            }

            public ValuesHolder WithValues(params string[] valuesToInsert) => new ValuesHolder(this, valuesToInsert);

            internal ValuesHolder WithValues(ColumnsHolder columns, params string[] valuesToInsert) => new ValuesHolder(this, columns, valuesToInsert);

            public ColumnsHolder AtColumns(params string[] columnsNames) => new ColumnsHolder(this, columnsNames);
        }
    }
}