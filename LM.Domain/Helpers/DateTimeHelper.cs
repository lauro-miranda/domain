using System;

namespace LM.Domain.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetCurrentDate()
        {
            var date = DateTime.UtcNow;
            return date.ForBrazilDate();
        }
    }
}