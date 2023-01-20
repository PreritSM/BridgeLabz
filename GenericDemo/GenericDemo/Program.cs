using System;

namespace GenericDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            char[] chars = { 'a', 'b', 'c' }; 
            PrintArray<int>(arr);
            PrintArray<char>(chars);
        }

        public static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine($"The item displayed using Generic fn : {item}");
            }
        }
    }
}