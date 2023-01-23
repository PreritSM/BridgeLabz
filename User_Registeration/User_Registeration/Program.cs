using System;

namespace User_Registeration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the User Registeration Problem");
            RegexDemo reg = new RegexDemo();
            Console.WriteLine(reg.ValidateFirstName("Prerit"));


        }
    }
}