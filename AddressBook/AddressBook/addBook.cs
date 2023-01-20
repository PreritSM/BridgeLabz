using System;

namespace AddressBook
{
    public class Contacts
    {
        string FName="";
        string LName="";
        string Address="";
        string City="";
        string State="";
        int ZipCode;
        long P_No;
        string Email="";

        public void AddContact(string FName, string LName, string Address, string City, string State, int ZipCode,long P_No,string Email)
        {
             this.FName = FName;
             this.LName = LName;
             this.Address = Address;
             this.City = City;
             this.State = State;
             this.ZipCode = ZipCode;
             this.P_No = P_No;
             this.Email = Email;
        }

        public void Display()
        {
            Console.WriteLine($"{this.FName},{this.LName},{this.Address},{this.City},{this.State},{this.ZipCode},{this.P_No},{this.Email}");
        }
    }
}
