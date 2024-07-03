namespace Thanos.Common.Datastore;

public class Transaction
{
    public DateOnly? Date { get; set; }
    public decimal Amount { get; set; }
    public IEnumerable<string> Tags { get; set; }
}
