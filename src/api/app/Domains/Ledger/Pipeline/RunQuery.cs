
using System.Linq;

namespace Thanos.Domains.Ledger;

public class RunQuery (
    Datastore.Gateway _datastore,
    FrameResults.Builder _resultBuilder
){
    public async Task<Context> Invoke(Context context)
    {
        // pipeline check

        var result = _resultBuilder.Build(() => {

            //Func<Datastore.Transaction, bool> func = (f) => f.Date > context.Request.Start && f.Date < context.Request.End;
            
            //bool func2(Datastore.Transaction f) => f.Date > context.Request.Start && f.Date < context.Request.End;

            Func<Datastore.Transaction, bool> func;

            if (context.Request.End.HasValue && context.Request.Start.HasValue)
            {
                func = (f) => f.Date > context.Request.Start && f.Date < context.Request.End;
            }
            else
            {
                var tags = _datastore.Get<Datastore.Tag>().Select(t => t.Value);

                func = (f) => f.Tags.Intersect(tags).Count() == f.Tags.Count();
            }




            return context;
        });

        // result check

        return await Task.FromResult(context);
    }
}
