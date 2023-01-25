using System;
using System.IO;

namespace FileIOFunctions
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\223089626\source\BridgeLabz\TextFile1.txt";
            Console.WriteLine("Welcome to File IO Problems");
            FileExists(path);
            BinaryOperations Bin = new BinaryOperations();
            Bin.BinarySerialization();

        }

        public static bool FileExists(string path)
        {
            ;
            if (File.Exists(path)) 
            {
                Console.WriteLine("The file exists");
                return true;
            }
            else
            {
                Console.WriteLine("The file doesn't exists");
                return false;
            }

        }

        public static void ReadTheLines(string path)
        {   
            if (File.Exists(path))
            {
                    
            }
        }

        public static void WriteThelines(string path)
        {
            if (FileExists(path))
            {
                string data3 = "New Entries";
              //  File.AppendAllLines(path, data3);
              //  File.ReadAllLines(path);
            }
            else
            {
                Console.WriteLine("File doesnt exists");
            }

            
        }
    }
}