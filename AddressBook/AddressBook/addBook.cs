using System;
using System.Net.Http.Headers;

namespace AddressBook
{
    public interface IContactList
    {
        public void Add_Contact(Contacts item);
        public void Edit_Contact(string fname);
        public void Delete_Contact(string fname);
        public void Display();


    }

    
    public class Contacts
    {
        public string FName="";
        public string LName="";
        public string Address="";
        public string City="";
        public string State="";
        public int ZipCode;
        public long P_No;
        public string Email="";

        public Contacts(string FName, string LName, string Address, string City, string State, int ZipCode,long P_No,string Email)
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

    public class ContactList : IContactList
    {
       // public List<string> Contact_list;
        public Dictionary<string,Contacts> Add_Book;



        public ContactList() {
           // Contact_list = new List<string>();
            Add_Book = new Dictionary<string, Contacts>();
        }


        public void Add_Contact(Contacts item)
        {
           // Contact_list.Add(item.FName);
            Add_Book.Add(item.FName, item);
        }

        public void Edit_Contact(string fname) {

            Console.WriteLine("Select Between the options you want to change for the given first name");
            Console.WriteLine("1. Lastname");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. City");
            Console.WriteLine("4. State");
            Console.WriteLine("5. Zipcode");
            Console.WriteLine("6. Phone No");
            Console.WriteLine("7. Email");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option-1)
            {
                case 0:
                    Console.WriteLine("Please Enter The New Last Name");
                    string name = Console.ReadLine();
                    Add_Book[fname].LName = name;
                    break;
                case 1:
                    Console.WriteLine("Please Enter The New Address");
                    string name2 = Console.ReadLine();
                    Add_Book[fname].Address = name2;
                    break; 
                case 2:
                    Console.WriteLine("Please Enter The New City");
                    string name3 = Console.ReadLine();
                    Add_Book[fname].City = name3;
                    break;
                case 3:
                    Console.WriteLine("Please Enter The New State");
                    string name4 = Console.ReadLine();
                    Add_Book[fname].State = name4;
                    break;
                case 4:
                    Console.WriteLine("Please Enter The New ZipCode");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Add_Book[fname].ZipCode = num;
                    break;
                case 5:
                    Console.WriteLine("Please Enter the New Phone Number");
                    long num2 = Convert.ToInt32(Console.ReadLine());
                    Add_Book[fname].P_No= num2;
                    break;
                case 6:
                    Console.WriteLine("Please Enter the New Email Id");
                    string name5 = Console.ReadLine();
                    Add_Book[fname].LName = name5;
                    break;

                default: 
                    Console.WriteLine("Wrong Input");
                    break;

                    Console.WriteLine("\n");
            }
        }

        public void Delete_Contact(string fname)
        {
            if (Add_Book.ContainsKey(fname))
            {
                Add_Book.Remove(fname);
            }
            else
            { 
                Console.WriteLine($"No contact exists with First name {fname}"); 
            }
        }
        public void Display()
        {
            foreach (KeyValuePair <string,Contacts> item in Add_Book ) {
                Console.WriteLine($"{Add_Book[item.Key].FName}\n{Add_Book[item.Key].LName}\n{Add_Book[item.Key].Address}\n" +
                    $"{Add_Book[item.Key].City}\n{Add_Book[item.Key].State}\n{Add_Book[item.Key].ZipCode}\n" +
                    $"{Add_Book[item.Key].P_No}\n{Add_Book[item.Key].Email}\n\n");
            }
        }
    }
}
