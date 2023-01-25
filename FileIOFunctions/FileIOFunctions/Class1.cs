using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using FileIOFunctions;
using System.Net.Http.Json;

namespace FileIOFunctions
{
    class BinaryOperations
    {
        public void BinarySerialization()
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\FileIOFunctions\FileIOFunctions\BinaryText.txt";
            PersonData data = new PersonData();
            data.name = "Prerit";
            data.age = 21;
            Console.WriteLine("Function hit");
            FileStream file = File.OpenWrite(path);
            //FileStream file = new FileStream(@"C:\Users\223089864\Desktop\BridgeLabz\FileIO\BinaryFile.txt", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, data);
            file.Close();
        }
        public void BinaryDeserialization()
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\FileIOFunctions\FileIOFunctions\BinaryText.txt";
            FileStream file = File.OpenRead(path);

            BinaryFormatter formatter = new BinaryFormatter();
            PersonData person = (PersonData)formatter.Deserialize(file);
            Console.WriteLine("Person Details: " + person.name + " " + person.age);
        }
        public void JSONSerialization()
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\FileIOFunctions\FileIOFunctions\JsonFile.json";
            PersonData person = new PersonData("Pulkit", 27);
            string result = JsonConvert.SerializeObject(person);
            File.WriteAllText(path, result);

        }
        public void JSONDeserialize()
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\FileIOFunctions\FileIOFunctions\JsonFile.json";
            string result = File.ReadAllText(path);
            PersonData person = JsonConvert.DeserializeObject<PersonData>(result);
            Console.WriteLine("Person Details: " + person.name + " " + person.age);
        }
    }
}
