using LiteDB;
using Microsoft.Extensions.Options;

namespace Thanos.Common.Datastore;

public class Gateway(
    IOptions<Settings.Database> databaseSettings
){
    private readonly Settings.Database _databaseSettings = databaseSettings.Value;

    public void Get()
    {
        using var db = new LiteDatabase(_databaseSettings.Path);
    }
}
