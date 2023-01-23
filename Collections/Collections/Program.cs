using System;
using System.Collections.Generic;


namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);

            int[] ints = { 2, 1, 2 ,4,5,6};
            list.AddRange(ints);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n\n");

            list.Remove(2);

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}