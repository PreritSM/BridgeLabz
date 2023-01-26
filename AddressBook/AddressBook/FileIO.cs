using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class FileIO
    {
        public void WriteToTxt(ContactList contactList)
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\AddressBook\AddressBook\Contacts.txt";

            using (TextWriter writer = new StreamWriter(path)) 
            {
                foreach (KeyValuePair<string, Contacts> kvp in contactList.Add_Book) {
                    writer.WriteLine(string.Format($"ContactPerson : {kvp.Key} \n" +
                        $"Details : {kvp.Value.FName},{kvp.Value.LName},{kvp.Value.Address},{kvp.Value.City}" +
                        $",{kvp.Value.State},{kvp.Value.ZipCode},{kvp.Value.P_No},{kvp.Value.Email}"));
                }
            }

        }

        public void ReadFromTxt()
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\AddressBook\AddressBook\Contacts.txt";


            string[] txt = File.ReadAllLines(path);
            foreach (string line in txt)
            {
                Console.WriteLine(line);
            }

        }
    }
}
