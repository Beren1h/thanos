using Thanos.Common;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Forecasts.Compare;

public class ReadForecast (
    IOptions<Settings.Forecasts> _forecastSettings,
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

            var content = File.ReadAllLines($"{_forecastSettings.Value.Path}\\{context.Request.ForecastId}");
            var transactions = new List<Datastore.Transaction>();
            
            foreach(var line in content)
            {
                var split = line.Split('|');
                var amount = decimal.Parse(split[0]);
                var tags = split[1].Split(',');
                var days = split[2].Split(',');
                
                foreach(var day in days)
                {
                    var chronoId = DateOnly.Parse($"{context.Request.ForecastId}-{day}");
                    var transaction = new Datastore.Transaction {
                        Year = chronoId.Year,
                        Month = chronoId.Month,
                        Account = "",
                        Note = "",
                        Stamp = "",
                        Week = chronoId.FindWeek(),
                        Amount = amount,
                        Tags = tags
                    };
                    transactions.Add(transaction);
                }
            }

            context.Forecast = transactions;

            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
