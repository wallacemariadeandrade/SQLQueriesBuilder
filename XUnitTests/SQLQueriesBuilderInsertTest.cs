using System;
using SQLQueriesHelper;
using Xunit;

namespace XUnitTests
{
    public class SQLQueriesBuilderInsertTest
    {
        [Fact]
        public void InsertValuesAsText()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("Foo")
                .Values("A", "B", "C")
                .As(ColumnTypes.Text, ColumnTypes.Text, ColumnTypes.Text)
                .Build();
            var expected = "INSERT INTO Foo VALUES ('A', 'B', 'C')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsNonText()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("Foo")
                .Values("A", "B", "C")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Build();
            var expected = "INSERT INTO Foo VALUES (A, B, C)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsTextAndWithDifferentTypes()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("Foo")
                .Values("A", "B", "C")
                .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                .Build();
            var expected = "INSERT INTO Foo VALUES ('A', B, 'C')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsTextAndEspecifyingColumns()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("TABLE")
                .Values("fOO1", "FOO2", "FOO3")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .As(ColumnTypes.Text, ColumnTypes.Text, ColumnTypes.Text)
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES ('fOO1', 'FOO2', 'FOO3')";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesAsNonTextAndEspecifyingColumns()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("TABLE")
                .Values("fOO1", "FOO2", "FOO3")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, FOO3)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void InsertValuesFromDifferentTypesAndEspecifyingColumns()
        {
            var query = SQLInsertQueriesBuilder
                .InsertAt("TABLE")
                .Values("fOO1", "FOO2", "FOO3")
                .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
                .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
                .Build();
            var expected = "INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, FOO3)";
            Assert.True(query.Equals(expected), $"Error: '{query}' is different from '{expected}'");
        }

        [Fact]
        public void TryToInsertValuesMismatchingValuesAndTypesSizes()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLInsertQueriesBuilder
                    .InsertAt("Foo")
                    .Values("A", "B")
                    .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                    .Build();
                }
            );
            
            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLInsertQueriesBuilder
                    .InsertAt("Foo")
                    .Values("A", "B", "C")
                    .As(ColumnTypes.Text, ColumnTypes.NonText)
                    .Build();
                }
            );

            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLInsertQueriesBuilder
                    .InsertAt("Foo")
                    .Values("A", "B", "C")
                    .AtColumns("FOO1", "FOO2")
                    .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.Text)
                    .Build();
                }
            );

            Assert.Throws<ArgumentOutOfRangeException>(
                () => {
                    SQLInsertQueriesBuilder
                    .InsertAt("Foo")
                    .Values("A", "B")
                    .AtColumns("FOO1", "FOO2", "FOO3")
                    .As(ColumnTypes.Text, ColumnTypes.NonText)
                    .Build();
                }
            );
        }
    }
}