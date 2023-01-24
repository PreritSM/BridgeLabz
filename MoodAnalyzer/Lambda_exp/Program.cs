using System;
using Lambda_exp;

namespace LambdaExp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Person Management");
            List<Person> p_list = new List<Person>();
            AddingPerson(p_list);
            Console.WriteLine("\n");
            Display(p_list);
            Console.WriteLine("\n");
            RetrieveTwo(p_list);
            Console.WriteLine("\n");
            RetrieveTeen(p_list);
            Console.WriteLine("\n");
            Avg_Age(p_list);
            Console.WriteLine("\n");
            FindPerson(p_list, "Prerit");
        }
        
        public static void AddingPerson(List<Person> p_list)
        {
            p_list.Add(new Person() { SSN = 1, Name="Bala",Address ="Chennai",Age =16 });
            p_list.Add(new Person() { SSN = 2, Name="Prerit", Address="Mumbai",Age=32 });
            p_list.Add(new Person() { SSN = 3, Name ="Baruni", Address = "Coimbatore", Age= 48 });
            p_list.Add(new Person() { SSN = 4, Name = "Priya", Address = "Andhra", Age = 64 });

            
        }

        public static void Display(List <Person> p_list )
        {
            foreach (Person p in p_list)
            {
                Console.WriteLine(p.Name);
            }
            
        }

        public static void RetrieveTwo(List<Person> p_list)
        {
            var result = p_list.FindAll(x => x.Age<60).Take(2);
            foreach (Person person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void RetrieveTeen (List<Person> p_list)
        {
            var result = p_list.FindAll(x => x.Age >= 13 && x.Age < 18);
            foreach (Person person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void Avg_Age(List<Person> p_list)
        {
            var result = p_list.Average(x => x.Age);
            Console.WriteLine($"Average age of the Person are {result}");  
        }

        public static void FindPerson (List<Person> p_list, string name)
        {
            var result = p_list.Find(x => x.Name == name);
            Console.WriteLine($"{result.Name}");
        }

    }

  
}