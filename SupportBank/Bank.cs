using System.ComponentModel;

namespace SupportBank;

public interface IAccounts
{
string Name { get; set; }
decimal GetAccountBalance();
List<Transaction> Transactions { get; set; }
}

public class Account : IAccounts
{
    public Account()
    {
        Transactions=new List<Transaction>();
    }
public string Name { get; set; }
public decimal GetAccountBalance()
{
    decimal AccountBalance = 0;
    foreach (var transaction in Transactions)
    {
        if (transaction.From == Name)
        {
            AccountBalance -= transaction.Amount;
        }
        else
        {
            AccountBalance += transaction.Amount;
        }
    }
    
    return AccountBalance;  
}
public List<Transaction> Transactions { get; set; }
}
public class Bank
{
    private Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
    private List<Transaction> Transactions { get; set; }
    public Bank(string path)
    {
        var reader= new CsvFileReader();
        Transactions=reader.GetTransactionsFromFile(path);
        MakeAccount(Transactions);
    }
private void MakeAccount(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            if(!Accounts.ContainsKey(transaction.From))
            {
                Accounts.Add(transaction.From, new Account());
                
            }

            if(!Accounts.ContainsKey(transaction.To))
            {
                Accounts.Add(transaction.To, new Account());
            }

            var FromAccount = Accounts[transaction.From];
            var ToAccount = Accounts[transaction.To];

            FromAccount.Transactions.Add(transaction);
            ToAccount.Transactions.Add(transaction);  
        }
    }
    public void ListAll()
    {
        foreach(var account in Accounts)
        {
            Console.WriteLine($"Account {account.Key}: £{account.Value.GetAccountBalance()}");
        }
    }
    public void ListAccount(string name)
    {
      var account = Accounts[name];
      foreach(var transaction in account.Transactions)
      {
        Console.WriteLine(transaction.ToString());
      }
    }
}