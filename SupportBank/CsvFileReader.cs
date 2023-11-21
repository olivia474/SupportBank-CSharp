using System.Security.Cryptography.X509Certificates;
using NLog;

namespace SupportBank;
public class CsvFileReader
//declares a public class called CsvFileReader
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
public List<Transaction> GetTransactionsFromFile(string path)
//returns a list of transactions
//GetTransactionsFromFile method passes string path which is the file path to CSV file
    {
        List<Transaction>transactions = new List<Transaction>();
        //new list of transactions is created
     
        using(var reader = new StreamReader(path))
        //reads from the file at given path
        {

            Logger.Info($"Reading file \"{path}\"");

            reader.ReadLine();
            //first line of file is not printed

        int lineNumber = 2;

        while (!reader.EndOfStream)
        //creates a loop that continues as long as there is more data to be read
        {
            var line = reader.ReadLine();
            //reads all lines in the file
            var values = line.Split(',');
            //each line is split into values with commas

            DateOnly date;
            decimal amount;

            try
            {
                date = DateOnly.Parse(values[0]);
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {values[0]} as DateOnly");
                Logger.Error($"Error parsing line {lineNumber}: cannot parse {values[0]} as DateOnly");
                throw e;
            }

            try
            {
                amount = decimal.Parse(values[4]);
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {values[4]} as decimal");
                Logger.Error($"Error parsing line {lineNumber}: cannot parse {values[4]} as decimal");
                throw e;
            }
            
            Transaction transaction = new Transaction
            //declares new variable called transaction and initializes it as a new instance of the Transaction class 
            (
              DateOnly.Parse(values[0]),
              //parses first value in values arrays as a DateOnly object
              values[1],
              values[2],
              values[3],
              decimal.Parse(values[4])
            );

              transactions.Add(transaction);
              //adds the newly created transaction to the transactions list
        }
        }

        return transactions;
        //returns the list of transactions
    }
}