using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace SupportBank;

using NLog;
using NLog.Config;
using NLog.Targets;
internal class Program
{
    static void Main(string[] args)
    { 
      var config = new LoggingConfiguration();
      var target = new FileTarget { FileName = @"C:\Users\3408kz\OneDrive - BP\Documents\Training\SupportBank-CSharp\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
      config.AddTarget("File Logger", target);
      config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
      LogManager.Configuration = config;

      var bank = new Bank("C:\\Users\\3408kz\\OneDrive - BP\\Documents\\Training\\SupportBank-CSharp\\DodgyTransactions2015.csv");
      //declares variable called bank
      //creates a new instance of the Bank class with the path to a CSV file

      bank.ListAll();
      //calls the ListAll method on the bank object
      //lists all accounts with their balances

      bank.ListAccount("Tim L");
      //calls the ListAccount method on the bank object.
      //lists all the transactions of a specific account, in this case "Tim L"
    }
}