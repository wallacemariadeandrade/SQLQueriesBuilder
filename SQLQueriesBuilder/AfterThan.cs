using System;

namespace SQLQueriesBuilder
{
    public class AfterThan : ITextualCondition
    {
        private DateTime _date;
        private string _format;

        public AfterThan(DateTime date, string dateFormat)
        {
            _date = date;
            _format = dateFormat;
        }

        public string OperatorAsText => $">";

        public string ValueAsText => _date.ToString(_format);
    }
}