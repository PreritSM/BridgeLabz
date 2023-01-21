using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string []args) 
        {
            IContactList contactList = new ContactList();
            Console.WriteLine("Welcome to the Address Book");
            string FName = "Prerit";
            string LName = "Mittal";
            string Address = "Carnation";
            string City = "Kalyan";
            string State = "Maharashtra";
            int ZipCode = 421301;
            long P_No = 9324194329;
            string Email = "psmballer29@gmail.com";

            
            Contacts ContactObj = new Contacts(FName, LName, Address, City, State, ZipCode, P_No, Email);
            Contacts ContactObj2= new Contacts("Ayush", "Patel", "Wadhwa", "Kalyan", "Maharashtra", 421301, 8879572310, "lebronpatel04@gmail.com");
            contactList.Add_Contact(ContactObj);
            contactList.Add_Contact(ContactObj2);

            contactList.Display();

            contactList.Edit_Contact("Ayush");

            contactList.Delete_Contact("Prerit");

            contactList.Display();
        }
    }
}