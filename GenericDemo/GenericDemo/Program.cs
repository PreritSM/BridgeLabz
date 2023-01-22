using System;

namespace GenericDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            char[] chars = { 'a', 'b', 'c' }; 
            GenericLearn obj= new GenericLearn();
            obj.PrintArray<int>(arr);
            obj.PrintArray<char>(chars);

            Generic_Max max_obj = new Generic_Max();
            Console.WriteLine(max_obj.Find_Max_Int(1, 2, 3));
            Console.WriteLine(max_obj.Find_Max_Float((float)1.5,(float) 2.5,(float) 3.5));
            Console.WriteLine(max_obj.Find_Max_String("Apple", "Peach", "Banana"));


            Console.WriteLine(max_obj.Generic_Max_GenericVar<string>("Apple","Mango","Orange"));

            Console.WriteLine(max_obj.Generic_Max_Find<int>(arr));
            Console.WriteLine(max_obj.Generic_Max_Find<char>(chars));


        }



    }
}