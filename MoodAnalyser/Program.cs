using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Mood Analyser Test Case");

            MoodAnalysing mood = new MoodAnalysing("I Am Happy");
            Console.WriteLine(mood.AnalyseMood());
        }
    }
}
