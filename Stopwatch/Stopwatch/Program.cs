using System;
using System.Diagnostics;

namespace Stop_watch
{
    public class Program{
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Please start the timer by an event");
            Console.ReadKey();
            stopwatch.Start();

            Console.ReadKey();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format($"{ts.Hours}:{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}");
            Console.WriteLine("RunTime " + elapsedTime);


        }
    }
}