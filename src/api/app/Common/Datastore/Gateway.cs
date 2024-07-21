using System.Linq.Expressions;
using LiteDB;
using Thanos.Common.Datastore.Extensions;

namespace Thanos.Common.Datastore;

public class Gateway(
    IOptions<Settings.Database> databaseSettings
){
    private readonly Settings.Database _databaseSettings = databaseSettings.Value;
    
    public void Append<T>(T poco)
    {
        using (var db = new LiteDatabase(_databaseSettings.Path))
        {
            db.GetCollection<T>(poco.GetCollectionName()).Insert(poco);
        };
    }

    public bool Delete<T>(string id)
    {
        var poco = Activator.CreateInstance<T>();
        var objectId = new ObjectId(id);
        
        using (var db = new LiteDatabase(_databaseSettings.Path))
        {
            return db.GetCollection<T>(poco.GetCollectionName()).Delete(objectId);
        };        
    }

    public List<T> Get<T>()
    {
        var poco = Activator.CreateInstance<T>();
        
        using (var db = new LiteDatabase(_databaseSettings.Path))
        {

            return db.GetCollection<T>(poco.GetCollectionName())
                .Query()
                .ToList();
        };
    }

    public List<T> Get<T>(Expression<Func<T, bool>> clause)
    {
        var poco = Activator.CreateInstance<T>();

        using (var db = new LiteDatabase(_databaseSettings.Path))
        {
            return db.GetCollection<T>(poco.GetCollectionName())
                .Query()
                .Where(clause)
                .ToList();
        };
    }
}
