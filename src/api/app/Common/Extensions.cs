using System.Globalization;

namespace Thanos.Common;

public static class Extensions
{
    public static int FindWeek(this string date)
    {
        var chronoId = DateOnly.Parse(date);

        return FindWeek(chronoId);
    }

    public static int FindWeek(this DateOnly date)
    {
        return new CultureInfo("en-US")
            .Calendar
            .GetWeekOfYear (
                date.ToDateTime(TimeOnly.Parse("12:00 AM")),
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday
            );
    }
}
