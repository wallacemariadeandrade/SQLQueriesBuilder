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
            var expected = "SELECT * FROM EMPLOYEES WHERE ANNUAL_SALARY > 24000";
            var query = SQLSelectBuilder
                .SelectAllFrom("EMPLOYEES")
                .Where("ANNUAL_SALARY", new MajorThan(24000))
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectAllFromApplyingWhereWithAnd()
        {
            var expected = "SELECT * FROM EMPLOYEES WHERE ANNUAL_SALARY > 24000 AND HIRED_ON > 1990/01/01";
            var query = SQLSelectBuilder
                .SelectAllFrom("EMPLOYEES")
                .Where("ANNUAL_SALARY", new MajorThan(24000))
                .And("HIRED_ON", new AfterThan(new DateTime(1990, 1, 1), "yyyy/MM/dd"))
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectAllFromApplyingWhereWithAnds()
        {
            var expected = "SELECT * FROM EMPLOYEES WHERE ANNUAL_SALARY > 24000 AND HIRED_ON > 1990/01/01 AND HIRED_ON < 1990/12/01";
            var query = SQLSelectBuilder
                .SelectAllFrom("EMPLOYEES")
                .Where("ANNUAL_SALARY", new MajorThan(24000))
                .And("HIRED_ON", new AfterThan(new DateTime(1990, 1, 1), "yyyy/MM/dd"))
                .And("HIRED_ON", new BeforeThan(new DateTime(1990, 12, 1), "yyyy/MM/dd"))
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectColumnsApplyingWhere()
        {
            var expected = "SELECT ID, Name FROM Users WHERE DEPARTMENT_ID = 10";
            var query = SQLSelectBuilder
                .Select("ID", "Name")
                .From("Users")
                .Where("DEPARTMENT_ID", new EqualsTo(10))
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectColumnsApplyingWhereWithAnd()
        {
            var expected = "SELECT ID, Name FROM Users WHERE DEPARTMENT_ID = 10 AND ANNUAL_SALARY > 24000";
            var query = SQLSelectBuilder
                .Select("ID", "Name")
                .From("Users")
                .Where("DEPARTMENT_ID", new EqualsTo(10))
                .And("ANNUAL_SALARY", new MajorThan(24000))
                .Build();
            AssertTrue(query, expected);
        }

        [Fact]
        public void SelectColumnsApplyingWhereWithAnds()
        {
            var expected = "SELECT ID, Name FROM Users WHERE DEPARTMENT_ID = 10 AND ANNUAL_SALARY > 24000 AND HIRED_ON > 1990/01/01";
            var query = SQLSelectBuilder
                .Select("ID", "Name")
                .From("Users")
                .Where("DEPARTMENT_ID", new EqualsTo(10))
                .And("ANNUAL_SALARY", new MajorThan(24000))
                .And("HIRED_ON", new AfterThan(new DateTime(1990, 1, 1), "yyyy/MM/dd"))
                .Build();
            AssertTrue(query, expected);
        }
    }
}