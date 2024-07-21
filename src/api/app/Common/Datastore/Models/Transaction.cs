using LiteDB;

namespace Thanos.Common.Datastore;

public class Transaction
{
    public Transaction()
    {
    }

    [BsonCtor]
    public Transaction (
        ObjectId _id,
        int year,
        string account,
        int month,
        int week,
        string stamp,
        string note,
        decimal amount,
        IEnumerable<string> tags
    ){
        Id = _id;
        Year = year;
        Month = month;
        Week = week;
        Account = account;
        Stamp = stamp;
        Note = note;
        Amount = amount;
        Tags = tags;
    }

    public ObjectId Id { get; set; } = ObjectId.NewObjectId();
    public int Year { get; set; }
    public string Account { get; set; }
    public int Month { get; set; }
    public int Week { get; set; }
    public string Stamp { get; set; }
    public string Note { get; set; }
    public decimal Amount { get; set; }
    public IEnumerable<string> Tags { get; set; }
}

// public class Transaction
// {
//     public DateOnly? Date { get; set; }
//     public decimal Amount { get; set; }
//     public IEnumerable<string> Tags { get; set; }
// }

// public class Transaction
// {
//     public string Date { get; set; }
//     public decimal Amount { get; set; }
//     public string Tags { get; set; }
// }
