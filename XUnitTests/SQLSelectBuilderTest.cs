using SQLQueriesBuilder.Builder;
using Xunit;

namespace XUnitTests
{
    public class SQLSelectBuilderTest
    {
        private void AssertTrue(string query, string expected)
        {
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void SelectAllFrom()
        {
            var expected = "SELECT * FROM Products";
            var query = SQLSelectBuilder
                .SelectAllFrom("Products")
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectColumnsFrom()
        {
            var expected = "SELECT ID, Name, Price FROM Products";
            var query = SQLSelectBuilder
                .Select("ID", "Name", "Price")
                .From("Products")
                .Build();
            AssertTrue(query, expected);
        }
    }
}