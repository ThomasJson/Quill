using System;

namespace Template.Application.Common.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime ShortToSeconds(DateTime dateTime)
        {
            return new DateTime(dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond), dateTime.Kind);
        }
    }
}