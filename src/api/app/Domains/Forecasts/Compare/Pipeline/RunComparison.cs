using Thanos.Common;
using Thanos.Frame.Results.Extensions;

namespace Thanos.Domains.Forecasts.Compare;

public class RunComparison (
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        if (context.HandlingResult.IsFaulted())
        {
            return context;
        }

        var result = _resultBuilder.Build(() => {
            
            var union = context.Forecast.Union(context.Transactions);
            var tags = union.SelectMany(u => u.Tags).Distinct();
            var weeks = union.Select(u => u.Week).Distinct().Order();
            var sumByTag = new Dictionary<string, decimal>();
            var sumByTagByWeek = new Dictionary<int, Dictionary<string, decimal>>();

            foreach(var tag in tags)
            {
                var sum = union
                    .Where(u => u.Tags.Contains(tag))
                    .Sum(u => u.Amount)
                    ;

                sumByTag.Add(tag, sum);
            }

            foreach(var week in weeks)
            {
                var weekly = union.Where(u => u.Week == week);
                
                var weeklyTags = union
                    .Where(u => u.Week == week)
                    .SelectMany(u => u.Tags)
                    .Distinct();

                sumByTagByWeek.Add(week, []);

                foreach(var tag in weeklyTags)
                {
                    sumByTagByWeek[week].Add(tag, 0m);

                    var sum = weekly
                        .Where(u => u.Tags.Contains(tag))
                        .Sum(u => u.Amount)
                        ;

                    sumByTagByWeek[week][tag] = sum;
                }
            }


            // var group = union.GroupBy(u => u.Tags);
            // var sum = group.Select (
            //     g => new {
            //         key = g.Key,
            //         Value = g.Sum(s => s.Amount)
            //     }
            // );
            
            return context;
        });

        if (result.IsFaulted())
        {
            context.HandlingResult.Fault = result.Fault;
        }

        return await Task.FromResult(context);
    }
}
