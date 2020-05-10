using TimeZoneConverter;

namespace System
{
    public static class DateTimeExtensions
    {
        public static DateTime ForBrazilDate(this DateTime dateTime)
            => TimeZoneInfo.ConvertTimeFromUtc(dateTime, TZConvert.GetTimeZoneInfo("E. South America Standard Time"));
    }
}