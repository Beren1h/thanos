using LiteDB;
using Thanos.Common.Datastore.Metadata.Extensions;

namespace Thanos.Common.Datastore.Metadata;

public class Gateway (
    IOptions<Settings.Database> databaseSettings
){
    private readonly Settings.Database _databaseSettings = databaseSettings.Value;

    // public void Append(Account account)
    // {
    //     using(var db = new LiteDatabase(_databaseSettings.Path))
    //     {
    //         var collection = db.GetCollection<Account>("accounts");
            
    //         collection.Insert(account);
    //     };
    // }

    // public void Append(Category category)
    // {
    //     using(var db = new LiteDatabase(_databaseSettings.Path))
    //     {
    //         var collection = db.GetCollection<Category>("categories");
            
    //         collection.Insert(category);
    //     };
    // }

    // public void Append(Forecast forecast)
    // {
    //     using(var db = new LiteDatabase(_databaseSettings.Path))
    //     {
    //         var collection = db.GetCollection<Forecast>("forecasts");
            
    //         collection.Insert(forecast);
    //     };
    // }

    // public void Append(Action action)
    // {
    //     using(var db = new LiteDatabase(_databaseSettings.Path))
    //     {
    //         var collection = db.GetCollection<Action>("actions");
            
    //         collection.Insert(action);
    //     };
    // }

    public void Append<T>(T poco)
    {
        using (var db = new LiteDatabase(_databaseSettings.Path))
        {
            var collection = db.GetCollection<T>(poco.GetCollectionName());
            
            collection.Insert(poco);
        };
    }
}
