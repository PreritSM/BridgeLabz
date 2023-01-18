using System;
using System.Net.Http.Headers;

namespace line_comp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the assignment on Line Comparision");

            //line_comp myObj2 = new line_comp();
            //myObj2.lineLength();
            //myObj2.equalLengthChecker();
            //myObj2.lineLengthComparison();

            Console.WriteLine("Welcome to the Line Comparison");
            IComparison obj = new Comparison();

            Console.WriteLine("Enter the coordinates for first line: ");
            int x1, y1, x2, y2;
            Console.WriteLine("Enter the X coordinate of first end point : ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Y coordinate of first end point : ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the X coordinate of second end point : ");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate of second end point : ");
            y2 = Convert.ToInt32(Console.ReadLine());

            obj.Linepts(x1, y1, x2, y2);

            Console.WriteLine("Enter the coordinates for first line: ");
            Console.WriteLine("Enter the X coordinate of first end point : ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Y coordinate of first end point : ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the X coordinate of second end point : ");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate of second end point : ");
            y2 = Convert.ToInt32(Console.ReadLine());

            obj.Linepts(x1, y1, x2, y2);

            obj.lenComp();

        }
    }
}