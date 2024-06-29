using Thanos.Common.Datastore.Metadata;

namespace Thanos.Common.Datastore;

public abstract class Event
{
    public abstract string StreamId { get; }
    public DateTime Timestamp { get; set; }
}

public class TransactionEvent : Event
{
    public override string StreamId => Transaction.TransactionId;
    public Transaction Transaction { get; set; }    
}

public class CategoryEvent : Event
{
    public override string StreamId => Transaction.CategoyId;
    public Transaction Transaction { get; set; }    
}

public class AccountEvent : Event
{
    public override string StreamId => Transaction.AccountId;
    public Transaction Transaction { get; set; }
}

public class KindEvent : Event
{
    public override string StreamId => Transaction.KindId;
    public Transaction Transaction { get; set; }
}

// public class Action
// {
//     public string ActionId { get; set; }
//     public string Display { get; set; }
// }

// public class Tag
// {
//     public string TagId { get; set; }
//     public string Display { get; set; }
// }

// public class Account
// {
//     public string AccountId { get; set; }
//     public string Display { get; set; }
// }

// public class Category
// {
//     public string CategoyId { get; set; }
//     public string Display { get; set; }
//     public List<Category> SubCategories { get; set; }
// }

public class Transaction
{
    public DateOnly Date { get; set; }
    //public string Category { get; set; }
    public decimal Amount { get; set; }
    //public List<string> Tags { get; set; }
    //public List<Tag> Tags { get; set; }
    public string TransactionId { get; set; }
    //public string ActionId { get; set; }
    public string AccountId { get; set; }
    public string CategoyId { get; set; }
    public string KindId { get; set; }
    //public bool IsReconciled { get; set; }
    //public bool IsForecast { get; set; }
}
