using System.Reflection.Metadata.Ecma335;

namespace SupportBank;
public class Transaction
//declares a public class called Transaction

{
     public DateOnly Date { get; set; }
     //declares a public property called Date of type DateOnly
     //get returns a value for Date
     //set assigns value to Date
     public string From { get; set;}
     public string To { get; set;}
     public string Narrative { get; set;}
     public decimal Amount { get; set;}

     
     public Transaction(DateOnly date, string from, string to, string narrative, decimal amount)
     //constructor for Transaction class
     //constructor passes parameters and assigns them to properties of the class
     {
        Date = date;
        //assigns the value of date parameter to the Date property of the class
        From = from;
        To = to;
        Narrative = narrative;
        Amount = amount;
     }
    
    public override string ToString()
    //declares a public method called ToString that overrides the ToString method
    {
        return $"{Date}: £{Amount} from {From} to {To}, for \"{Narrative}\"";
        //returns a string that represents current transaction
    }
}