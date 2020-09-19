using Xunit;
using SQLQueriesHelper;
using System.Linq;

namespace XUnitTests
{
    public class SQLQueriesHelperTest
    {
        string inputDataWithOneQuote = @"This text contains one quote """;
        string inputDataWithTwoQuotes = @"This text contains two quotes: one here "" and other here """;
        string inputDataWithOneApostrophe = "This text contains one apostrophe '";
        string inputDataWithTwoApostrophes = "'This text begins and ends with apostrophes'";

        [Fact]
        public void TestEscapeQuotesWithOneQuoteOnQuery()
        {
            var query = $"INSERT INTO CLASS VALUE ('{inputDataWithOneQuote.EscapeQuotes()}')";
            Assert.False(query.Contains(@""""), "Fail: the query contains quotes on it and will not be succesfully executed on the server.");
        }

        [Fact]
        public void TestEscapeQuotesWithTwoQuotesOnQuery()
        {
            var query = $"INSERT INTO CLASS VALUE ('{inputDataWithTwoQuotes.EscapeQuotes()}')";
            Assert.False(query.Contains(@""""), "Fail: the query contains quotes on it and will not be succesfully executed on the server.");
        }

        [Fact]
        public void TestUnescapeQuotes()
        {
            var escapedWithOneQuote = inputDataWithOneQuote.EscapeQuotes();
            var escapedWithTwoQuotes = inputDataWithTwoQuotes.EscapeQuotes();
            Assert.Equal<string>(escapedWithOneQuote.UnescapeQuotes(), inputDataWithOneQuote);
            Assert.Equal<string>(escapedWithTwoQuotes.UnescapeQuotes(), inputDataWithTwoQuotes);
        }

        [Fact]
        public void TestEscapeApostrophesWithOneApostropheOnQuery()
        {
            var query = $"INSERT INTO CLASS VALUE ('{inputDataWithOneApostrophe.EscapeApostrophes()}')";
            Assert.False(query.Count(s => s.ToString().Equals("'")) > 2, "Fail: the query contains apostrophes on it and will not be succesfully executed on the server.");
        }

        [Fact]
        public void TestEscapeApostrophesWithTwoApostropheOnQuery()
        {
            var query = $"INSERT INTO CLASS VALUE ('{inputDataWithTwoApostrophes.EscapeApostrophes()}')";
            Assert.False(query.Count(s => s.ToString().Equals("'")) > 2, "Fail: the query contains apostrophes on it and will not be succesfully executed on the server.");
        }

        [Fact]
        public void TestUnescapeEscapeApostrophes()
        {
            var escapedWithOneApostrophe = inputDataWithOneApostrophe.EscapeApostrophes();
            var escapedWithTwoApostrophes = inputDataWithTwoApostrophes.EscapeApostrophes();
            Assert.Equal<string>(escapedWithOneApostrophe.UnescapeApostrophes(), inputDataWithOneApostrophe);
            Assert.Equal<string>(escapedWithTwoApostrophes.UnescapeApostrophes(), inputDataWithTwoApostrophes);
        }

        [Fact]
        public void TestEscapeApostrophesAndEscapeQuotesTogetherOnQuery()
        {
            var query = $"INSERT INTO CLASS VALUES ('{(inputDataWithTwoQuotes + inputDataWithOneApostrophe + inputDataWithTwoQuotes).EscapeQuotes().EscapeApostrophes()}'";
            Assert.False(query.Contains(@""""), $"Fail: the query [{query}] contains quotes on it and will not be succesfully executed on the server.");
            Assert.False(query.Count(s => s.ToString().Equals("'")) > 2 , $"Fail: the query [{query}] contains apostrophes on it and will not be succesfully executed on the server.");
        }

        [Fact]
        public void TestUnescapeEscapeApostrophesAndUnescapeQuotesTogether()
        {
            var mixedInputData = inputDataWithTwoApostrophes + inputDataWithOneQuote + inputDataWithTwoQuotes + inputDataWithOneApostrophe;
            Assert.Equal<string>(mixedInputData.EscapeApostrophes().EscapeQuotes().UnescapeQuotes().UnescapeApostrophes(), mixedInputData);
        }
    }
}
