using System;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string []args) 
        {
            ContactList contactList = new ContactList();
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
            Contacts ContactObj2= new Contacts("Ayush", "Patel", "Wadhwa", "Thane", "Maharashtra", 421301, 8879572310, "lebronpatel04@gmail.com");
            contactList.Add_Contact(ContactObj);
            contactList.Add_Contact(ContactObj2);

            contactList.Display();
            Console.WriteLine("\n");
            contactList.Edit_Contact("Ayush");


            ContactList contactList2 = new ContactList();
            Contacts ContactObj3 = new Contacts("Nishit", "Jain", "Wadhwani Heights", "Bhiwandi", "Kerala", 421502, 8879572310, "nishiboy@gmail.com");
            contactList2.Add_Contact(ContactObj3);

            AddressBookDict contactDict = new AddressBookDict();
            contactDict.Add_To_Book_Dict("Young Guys",contactList);
            contactDict.Add_To_Book_Dict("Far Guys", contactList2);

            contactDict.Search_using_city_state();

            contactDict.get_count_city();
            contactDict.get_count_state();
        }
    }
}