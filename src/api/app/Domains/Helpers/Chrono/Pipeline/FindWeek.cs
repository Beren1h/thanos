using System.Globalization;
using FluentValidation;
using Thanos.Frame.Results.Extensions;
using Thanos.Frame.Validation.Extensions;

namespace Thanos.Domains.Helpers.Chrono;

public class FindWeek (
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        if (context.HandlingResult.IsFaulted())
        {
            return context;
        }

        var result = _resultBuilder.Build(() => {
            
            DateTime a = DateTime.Parse($"{context.Request.Year}-{context.Request.Month}-1");
            DateOnly b = DateOnly.Parse($"{context.Request.Year}-{context.Request.Month}-1");

            var days = DateTime.DaysInMonth(context.Request.Year, context.Request.Month);
            var weeks = new Dictionary<int, List<string>>();

            for (var i = 1; i <= days; i++)
            {
                var date = DateOnly.Parse($"{context.Request.Year}-{context.Request.Month}-{i}");
                var calendar = new CultureInfo("en-US").Calendar;
                var week = calendar.GetWeekOfYear(date.ToDateTime(TimeOnly.Parse("12:00 AM")), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                weeks.TryAdd(week, []);
                weeks[week].Add(date.ToString("yyyy-MM-dd"));
            }

            context.HandlingResult.Resource = weeks;

            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
