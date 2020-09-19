using System;

namespace SQLQueriesHelper
{
    ///
    /// <summary>
    /// Utilities to facilitate writing SQL queries 
    /// </summary>
    ///
    public static class SQLQueriesHelper
    {
        /// <summary>
        /// Removes quotes replacing it by '&quote'.
        /// </summary>
        /// <returns>
        /// A string containg '&quote' where it was a "'.
        /// </returns>
        public static string EscapeQuotes(this string s) => s.Replace(@"""", "&quote");
        
        /// <summary>
        /// Removes apostrophes replacing it by '&apos'.
        /// </summary>
        /// <returns>
        /// A string containg '&apos' where it was a '.
        /// </returns>
        public static string EscapeApostrophes(this string s) => s.Replace("'", "&apos");
        
        /// <summary>
        /// Removes '&quote' replacing it by quotes.
        /// </summary>
        /// <returns>
        /// A string containg " where it was '&quote'.
        /// </returns>
        public static string UnescapeQuotes(this string s) => s.Replace("&quote", @"""");

        /// <summary>
        /// Removes '&apos' replacing it by an apostrophe'.
        /// </summary>
        /// <returns>
        /// A string containg ' where it was '&apos'.
        /// </returns>
        public static string UnescapeApostrophes(this string s) => s.Replace("&apos", "'");
    }
}
