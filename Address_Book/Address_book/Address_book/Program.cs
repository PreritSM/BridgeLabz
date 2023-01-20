using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string []args) 
        {
            Console.WriteLine("Welcome to the Address Book");
            List <Contacts> ContactList = new List <Contacts> ();
            string FName = "Prerit";
            string LName = "Mittal";
            string Address = "Carnation";
            string City = "Kalyan";
            string State = "Maharashtra";
            int ZipCode = 421301;
            long P_No = 9324194329;
            string Email = "psmballer29@gmail.com";

            
            Contacts ContactObj = new Contacts();
            ContactObj.AddContact(FName, LName, Address, City, State, ZipCode, P_No, Email);
            ContactList.Add(ContactObj);
            Contacts ContactObj2= new Contacts();
            ContactObj2.AddContact("Ayush", "Patel", "Wadhwa", "Kalyan", "Maharashtra", 421301, 8879572310, "lebronpatel04@gmail.com");
            ContactList.Add(ContactObj2);

            foreach (Contacts item in ContactList)
            {
                item.Display();
            }
        }
    }
}