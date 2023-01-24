using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer");

            MoodAnalyzer mood = new MoodAnalyzer();

            Console.WriteLine(mood.AnalyzeMood("I am in a Happy mood"));
            Console.WriteLine(mood.AnalyzeMood("I am in a Sad mood"));

            Console.WriteLine(mood.AnalyzeMood(null)); ;
        }
    }
}