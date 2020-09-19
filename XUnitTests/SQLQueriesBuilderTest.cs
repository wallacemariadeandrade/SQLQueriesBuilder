using System;
using SQLQueriesHelper;
using Xunit;

namespace XUnitTests
{
    public class SQLQueriesBuilderTest
    {
        [Fact]
        public void InsertValuesAsText()
        {
            var query = SQLQueriesBuilder
                .InsertAt("Foo")
                .WithValues("A", "B", "C")
                .As(ColumnTypes.Text, ColumnTypes.Text, ColumnTypes.Text)
                .Builder()
                .Build();
            var expected = "INSERT INTO Foo VALUES ('A', 'B', 'C')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsNonText()
        {
            var query = SQLQueriesBuilder
                .InsertAt("Foo")
                .WithValues("A", "B", "C")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Builder()
                .Build();
            var expected = "INSERT INTO Foo VALUES (A, B, C)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsTextAndWithDifferentTypes()
        {
            var query = SQLQueriesBuilder
                .InsertAt("Foo")
                .WithValues("A", "B", "C")
                .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                .Builder()
                .Build();
            var expected = "INSERT INTO Foo VALUES ('A', B, 'C')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void TryToInsertValuesMismatchingValuesAndTypesSizes()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLQueriesBuilder
                    .InsertAt("Foo")
                    .WithValues("A", "B")
                    .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                    .Builder()
                    .Build();
                }
            );
            
            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLQueriesBuilder
                    .InsertAt("Foo")
                    .WithValues("A", "B", "C")
                    .As(ColumnTypes.Text, ColumnTypes.NonText)
                    .Builder()
                    .Build();
                }
            );

            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLQueriesBuilder
                    .InsertAt("Foo")
                    .AtColumns("FOO1", "FOO2")
                    .WithValues("A", "B", "C")
                    .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                    .Builder()
                    .Build();
                }
            );

            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLQueriesBuilder
                    .InsertAt("Foo")
                    .AtColumns("FOO1", "FOO2", "FOO3")
                    .WithValues("A", "B")
                    .As(ColumnTypes.Text, ColumnTypes.NonText)
                    .Builder()
                    .Build();
                }
            );
        }

        [Fact]
        public void InsertValuesAsTextAndEspecifyingColumns()
        {
            var query = SQLQueriesBuilder.InsertAt("TABLE")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .WithValues("fOO1", "FOO2", "FOO3")
                .As(ColumnTypes.Text, ColumnTypes.Text, ColumnTypes.Text)
                .Builder()
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES ('fOO1', 'FOO2', 'FOO3')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsNonTextAndEspecifyingColumns()
        {
            var query = SQLQueriesBuilder.InsertAt("TABLE")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .WithValues("fOO1", "FOO2", "FOO3")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Builder()
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, FOO3)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesFromDifferentTypesAndEspecifyingColumns()
        {
            var query = SQLQueriesBuilder.InsertAt("TABLE")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .WithValues("fOO1", "FOO2", "FOO3")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Builder()
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, FOO3)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }
    }
}