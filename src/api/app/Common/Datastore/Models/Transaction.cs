namespace Thanos.Common.Datastore;

public class Transaction
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Week { get; set; }
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
