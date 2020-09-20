using SQLQueriesHelper;
using Xunit;

namespace XUnitTests
{
    public class SQLQueriesBuilderSelectTest
    {
        [Fact]
        public void SelectAllColumns()
        {
            var query = SQLSelectQueriesBuilder
                .SelectAllFrom("Foo")
                .Builder()
                .Build();
            var expected = "SELECT * FROM Foo";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void SelectEspecifyingColumns()
        {
            var expected = "SELECT COLUMN1, COLUMN2, COLUMN3 FROM FOO";
            var query = SQLSelectQueriesBuilder
                .SelectFrom("FOO")
                .Columns("COLUMN1", "COLUMN2", "COLUMN3")
                .Builder()
                .Build();
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }
    }
}