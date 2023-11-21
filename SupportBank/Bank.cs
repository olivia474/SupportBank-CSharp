using System.ComponentModel;

namespace SupportBank;


public interface IAccounts
//declares public interface called IAccounts
{
string Name { get; set; }
//declares a property called Name
decimal GetAccountBalance();
//method that returns a decimal
List<Transaction> Transactions { get; set; }
//declares a property called Transactions
//get returns a value for Transactions
//set assigns value to Transactions
}

public class Account : IAccounts
//declares a public class called Account that implements the IAccount interface
{
    public Account()
    //declares a public constructor for the Account class
    {
        Transactions = new List<Transaction>();
        //creates a new empty list of Transaction objects and assigns it to the Transactions property
    }
public string Name { get; set; }
//declares public property called Name of type string
//get returns a value for Name
//set returns a value for Name

public decimal GetAccountBalance()
//declares public method called GetAccountBalance that returns decimal value
{
    decimal AccountBalance = 0;
    //declares variable AccountBalance and sets it to 0
    foreach (var transaction in Transactions)
    //iterates over each transaction in the Transactions list
    {
        if (transaction.From == Name)
        //if name of transaction.From is equal to Name
        {
            AccountBalance -= transaction.Amount;
            //transaction amount is subtracted from account balance
        }
        else
        {
            AccountBalance += transaction.Amount;
            //otherwise added to account balance
        }
    }
    
    return AccountBalance;
    //returns calculated account balance
}
public List<Transaction> Transactions { get; set; }
//declares a public property called Transactions
//get returns a value for Transaction
//set returns a value for Transaction
}
public class Bank
//declares a public class called Bank
{
    private Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
    
    private List<Transaction> Transactions { get; set; }
    //declares property called Transactions
    public Bank(string path)
    //declares public constructor for the Bank class and passes string path
    {
        var reader = new CsvFileReader();
        //declares variable called reader and intializes a new instance of the CsvFileReader class
        Transactions = reader.GetTransactionsFromFile(path);
        //calls the GetTransactionsFile method on the reader object and passes in path
        //returns a list of transactions which is then assigned to Transactions property
        MakeAccount(Transactions);
        //passes the Transaction property in MakeAccount method
    }
private void MakeAccount(List<Transaction> transactions)
//declares private method called MakeAccount that takes transactions
//void means method does not return a value
    {
        foreach (var transaction in transactions)
        //iterates over each transaction in the transactions list
        {
            if(!Accounts.ContainsKey(transaction.From))
            //checks if Accounts dictionary contains keys from the From property of the current transaction
            {
                Accounts.Add(transaction.From, new Account());
                
                
            }

            if(!Accounts.ContainsKey(transaction.To))
            //checks if Accounts dictionary contains keys from the To property of the current transaction
            {
                Accounts.Add(transaction.To, new Account());
                
            }

            var FromAccount = Accounts[transaction.From];
            //declares variable called FromAccount...
            
            var ToAccount = Accounts[transaction.To];

            FromAccount.Transactions.Add(transaction);
            //adds current transactions to the Transactions list of FromAccount
            ToAccount.Transactions.Add(transaction);
            // adds the current transaction to the Transaction list of ToAccount
        }
    }
    public void ListAll()
    //declares a public method called ListAll
    {
        foreach(var account in Accounts)
        //iterates over each account in the Accounts dictionary
        {
            Console.WriteLine($"Account {account.Key}: £{account.Value.GetAccountBalance()}");
            //prints out account name and account balance
        }
    }
    public void ListAccount(string name)
    //declares a public method called ListAccount and passes string name
    {
      var account = Accounts[name];
      //declares a variable called account
      //assigns
      
      foreach(var transaction in account.Transactions)
      //iterates over each transaction in the Transactions list of the account
      {
        Console.WriteLine(transaction.ToString());
        //prints transaction
      }
    }
}