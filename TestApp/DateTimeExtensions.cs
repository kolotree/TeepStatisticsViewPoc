using System;
using System.Collections.Generic;

namespace TestApp
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime BeggingOfTime = new DateTime(2021, 1, 1);
        
        public static long TotalHours(this DateTime dateTime)
        {
            if (dateTime < BeggingOfTime) throw new ArgumentException($"DateTime can't be before {BeggingOfTime}");
            return (long)(dateTime - BeggingOfTime).TotalHours;
        }
    }
}