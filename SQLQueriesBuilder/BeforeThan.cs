using System;

namespace SQLQueriesBuilder
{
    public class BeforeThan : ITextualCondition
    {
        private DateTime _date;
        private string _format;

        public BeforeThan(DateTime date, string dateFormat)
        {
            _date = date;
            _format = dateFormat;
        }

        public string GetCondition => $"< {_date.ToString(_format)}";
    }
}