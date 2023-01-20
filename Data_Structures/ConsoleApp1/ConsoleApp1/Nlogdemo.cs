using System;
using NLog;
namespace LinkedList
{


	public class Nlogdemo
	{	//Logger logger = LogManager.GetCurrentClassLogger();'
		NlogData logger= new NlogData();
		public void start()
		{
            Console.WriteLine("Welcome to the program on swapping two numbers");
			Console.WriteLine("Enter the first Number");
			int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second Number");
            int y = Convert.ToInt32(Console.ReadLine());

			NlogData.DebugInfo("Debug Successful");

			swapper(x, y);
			NlogData.Infolevel("Code executed");
        }
		public void swapper (int x, int y)
		{
			int temp = x;
			x = y;
			y = temp;

			Console.WriteLine($"The new first number is : {x}");
			Console.WriteLine($"The new second number is {y}");

		}
	}
}