using System;

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



        }
    }
}