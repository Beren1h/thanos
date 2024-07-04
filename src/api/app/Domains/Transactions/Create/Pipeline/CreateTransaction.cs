using System.Globalization;
using Thanos.Common.Datastore;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Transactions.Create;

public class CreateTransaction (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        if (context.HandlingResult.IsFaulted())
        {
            return context;
        }

        var result = _resultBuilder.Build(() => {

            var chronoTag = DateOnly.Parse(context.Request.ChronoTag);

            var year = chronoTag.Year;
            var month = chronoTag.Month;
            var calendar = new CultureInfo("en-US").Calendar;
            var week = calendar.GetWeekOfYear(chronoTag.ToDateTime(TimeOnly.Parse("12:00 AM")), CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            // var x = context.Request.Date.HasValue ? context.Request.Date.Value.ToString("yyyy-MM-dd") : null;
            // var orderedTags = context.Request.Tags.Order();
            // var tagline = string.Join("@", orderedTags);

            var transaction = new Transaction {
                Year = year,
                Month = month,
                Week = week,
                Date = context.Request.Date.HasValue ? context.Request.Date.Value : null,
                Amount = context.Request.Amount,
                Tags = context.Request.Tags
            };

            _datastore.Append(transaction);

            context.HandlingResult.Resource = transaction;
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
