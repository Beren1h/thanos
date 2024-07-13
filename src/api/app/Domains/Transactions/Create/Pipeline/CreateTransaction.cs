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

            var chronoId = DateOnly.Parse(context.Request.ChronoId);

            var transaction = new Transaction {
                Year = chronoId.Year,
                Month = chronoId.Month,
                Account = context.Request.Account,
                Note = context.Request.Note,
                Stamp = string.IsNullOrEmpty(context.Request.Stamp) ? "forecast" : context.Request.Stamp,
                Week = new CultureInfo("en-US").Calendar
                    .GetWeekOfYear(chronoId.ToDateTime(TimeOnly.Parse("12:00 AM")),
                        CalendarWeekRule.FirstDay,
                        DayOfWeek.Monday
                     ),
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
