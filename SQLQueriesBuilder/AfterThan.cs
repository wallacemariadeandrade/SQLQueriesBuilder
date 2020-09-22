using System;

namespace SQLQueriesBuilder
{
    public class AfterThan : ITextualCondition
    {
        private DateTime _date;

        public AfterThan(DateTime date)
        {
            _date = date;
        }

        public string GetCondition => $"> {_date.ToShortDateString()}";
    }
}