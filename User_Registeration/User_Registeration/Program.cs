using System;
using System.Text.RegularExpressions;
namespace User_Registeration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the User Registeration Problem");
            RegexDemo reg = new RegexDemo();

            Console.WriteLine($"The First Name follows the pattern : {reg.ValidateFirstName("Prerit")}");

            Console.WriteLine($"The Last Name follows the pattern : {reg.ValidateLastName("Mittal")}");
            Console.WriteLine($"The Email follows the pattern : " +
                $"{reg.ValidateEmail("prerit.mittal@gmail.com.in")}");
            Console.WriteLine($"The Phone Number follows the pattern : " +
                $"{reg.ValidatePhoneNumber("91 8879572310")}");
            Console.WriteLine($"The Password follows the pattern : " +
                $"{reg.ValidatePassword("Prerit@29")}");

            // Using LAMBDA FUNCTIONS

            string FirstNamePattern = "^[A-Z][a-z]{2,}$";
            string LastNamePattern = "^[A-Z][a-z]{2,}";
            string EmailPattern = "^[A-Za-z]+\\.?[A-Za-z]+@[A-Za-z]+\\.[A-Za-z]+\\.?[A-Za-z]+";
            string PhonePattern = "^[0-9]{2,3}\\s[0-9]{10}";

            Console.WriteLine("Output using the Lambda function");
            List <string> Fnames = new List<string> { "Gustav","no","Ape"};
            List<string> Lnames = new List<string> { "Ramirez", "Ho", "Great" };
            List<string> Emails = new List<string> { "prerit.mittal@gmail.com", "lebronpatel@yahoo.co.in" };
            List<string> Phones = new List<string> { "9 9939393213" };

            // Simple use of Lambda function
            var result = Fnames.FindAll(x => Regex.IsMatch(x, FirstNamePattern));
            Console.Write("Number of FirstNames that satify the rules : ");
            Console.WriteLine(result.Count);
            var result2 = Lnames.FindAll(x => Regex.IsMatch(x, LastNamePattern));
            Console.Write("Number of FirstNames that satify the rules : ");
            Console.WriteLine(result2.Count);
            var result3 = Emails.FindAll(x => Regex.IsMatch(x, EmailPattern));
            Console.Write("Number of FirstNames that satify the rules : ");
            Console.WriteLine(result3.Count);
            var result4 = Phones.FindAll(x => Regex.IsMatch(x, PhonePattern));
            Console.Write("Number of FirstNames that satify the rules : ");
            Console.WriteLine(result4.Count);


        }
    }
}