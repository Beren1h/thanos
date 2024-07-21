namespace Thanos.Domains.Transactions.Get;

public class Response(
    Datastore.Transaction transaction
){
    public string Id { get; set; } = transaction.Id.ToString();
    public int Year { get; set; } = transaction.Year;
    public int Month { get; set; } = transaction.Month;
    public int Week { get; set; } = transaction.Week;
    public string Stamp { get; set; } = transaction.Stamp;
    public string Account { get; set; } = transaction.Account;
    public string Note { get; set; } = transaction.Note;
    public decimal Amount { get; set; } = transaction.Amount;
    public IEnumerable<string> Tags { get; set; } = transaction.Tags;
}
