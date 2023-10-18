using System.Security.Cryptography.X509Certificates;

namespace SupportBank;
public class CsvFileReader
{
public List<Transaction> GetTransactionsFromFile(string path)
    {
        List<Transaction>transactions = new List<Transaction>();
     
        using(var reader = new StreamReader(path))
        {
            reader.ReadLine();

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            
            Transaction transaction = new Transaction
            (
              DateOnly.Parse(values[0]),
              values[1],
              values[2],
              values[3],
              decimal.Parse(values[4])
            );

              transactions.Add(transaction);
        }
        }
        
        return transactions;
    }
}