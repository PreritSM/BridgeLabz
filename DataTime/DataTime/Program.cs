using System;
using DataTime;

namespace DateTimeDemo
{
    public class Program
    {
        public static void Main(string[] args) { 
        DateTime presentDateTime = DateTime.Now;
        
        Console.WriteLine(presentDateTime.ToString());

        Console.WriteLine("\n");

        Time2Seconds time2Seconds = new Time2Seconds();
        Console.Write($"The number of seconds passed from 00:00:00 is -> {time2Seconds.ConvertTimeformat2Sec(presentDateTime)}");
        }
    }

}