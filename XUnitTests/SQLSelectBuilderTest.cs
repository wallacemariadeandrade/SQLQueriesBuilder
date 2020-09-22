using System;
using SQLQueriesBuilder;
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

        [Fact]
        public void SelectAllFromApplyingWhere()
        {
            var expected = "SELECT * FROM EMPLOYEES WHERE ANUAL_SALARY > 24000";
            var query = SQLSelectBuilder
                .SelectAllFrom("EMPLOYEES")
                .Where("ANUAL_SALARY", new MajorThan(24000))
                .Build();
            AssertTrue(query, expected);
        }
    }
}