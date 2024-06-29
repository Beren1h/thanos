using LiteDB;
using Microsoft.Extensions.Options;

namespace Thanos.Common.Datastore;

public class Gateway(
    IOptions<Settings.Database> databaseSettings    
){
    private readonly Settings.Database _databaseSettings = databaseSettings.Value;

    public List<Event> Stream(string transactionId)
    {
        List<Event> stream = [];

        using(var db = new LiteDatabase(_databaseSettings.Path))
        {
            var collection = db.GetCollection<Event>("events");
            
            stream = collection
                .Query()
                .Where(e => e.StreamId == transactionId)
                .ToList()
                ;
        };

        return stream;        
    }

    public void Append(Event @event)
    {
        using(var db = new LiteDatabase(_databaseSettings.Path))
        {
            var collection = db.GetCollection<Event>("events");
            @event.Timestamp = DateTime.UtcNow;
            var stream = collection.Insert(@event);
        };
    }
}