using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace SupportBank;
internal class Program
{
    static void Main(string[] args)
    { 
      var bank = new Bank("C:\\Users\\3408kz\\OneDrive - BP\\Documents\\Training\\SupportBank-CSharp\\Transactions2014.csv");
         
      bank.ListAll();

      bank.ListAccount("Tim L");
    }
}