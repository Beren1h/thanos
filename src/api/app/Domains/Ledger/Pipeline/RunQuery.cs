
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Thanos.Domains.Ledger;

public class RunQuery (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        // pipeline check

        var result = _resultBuilder.Build(() => {

            var date = new DateOnly(2024,06,24);
            var calendar = new CultureInfo("en-US").Calendar;
            var week = calendar.GetWeekOfYear(date.ToDateTime(TimeOnly.Parse("12:00 AM")), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            // Expression<Func<Datastore.Transaction, bool>> clause;

            // var tagline = string.Join("@", context.Request.Tags.Order());

            // clause = (t) => t.Tags.All(w => tagline.Contains(w));

            // var get = _datastore.Get(clause);

            // int x = 1;
            //var start = context.Request.Start.HasValue ? context.Request.Start.Value.ToString("yyyy-MM-dd") : null;
            //var end = context.Request.End.HasValue ? context.Request.End.Value.ToString("yyyy-MM-dd") : null;

            //Func<Datastore.Transaction, bool> clause = (f) => f.Date > start && f.Date < context.Request.End;
            //Func<Datastore.Transaction, bool> func = (f) => f.Date > context.Request.Start && f.Date < context.Request.End;
            
            //bool func2(Datastore.Transaction f) => f.Date > context.Request.Start && f.Date < context.Request.End;

            //Expression<Func<Datastore.Transaction, bool>> clause;

            //clause = (f) => f.Date > context.Request.Start && f.Date < context.Request.End;

            // if (context.Request.End.HasValue && context.Request.Start.HasValue)
            // {
            //     clause = (f) => f.Date > context.Request.Start && f.Date < context.Request.End;
            // }
            // else
            // {
            //     var tags = _datastore.Get<Datastore.Tag>().Select(t => t.Value);
            //     //var matching = context.Request.Tags.Intersect(tags);

            //     //clause = (f) => f.Tags.Intersect(tags).Count() == f.Tags.Count();
            //     //clause = (f) => f.Tags.All(t2 => !tags.Any(t1 => t2.Contains(t1)));
            //     //clause = (f) => f.Tags.All(a => context.Request.Tags.Contains(a));
            //     clause = (f) => f.Tags.Except(context.Request.Tags).Count() == f.Tags.Count() - context.Request.Tags.Count();
            // }

            // var get = _datastore.Get<Datastore.Transaction>(clause);
            // var get2 = _datastore.Get2();

            // var transactions = _datastore.Get<Datastore.Transaction>();

            // var test = transactions.Where(t => t.Date > context.Request.Start && t.Date < context.Request.End);

            // var match = new List<Datastore.Transaction>();

            // foreach(var transaction in transactions)
            // {
            //     var all = true;

            //     foreach(var tag in context.Request.Tags)
            //     {
            //         if(!transaction.Tags.Contains(tag))
            //         {
            //             all = false;
            //             break;
            //         }
            //     }

            //     if (all)
            //     {
            //         match.Add(transaction);
            //     }
            // }

            return context;
        });

        // result check

        return await Task.FromResult(context);
    }
}
