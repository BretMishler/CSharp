using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //behind the scenes a constructor method is being invoked so () required
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            // cw tab tab for console.writeLine();
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);

            // value inside of book is copied and placed inside book 2 (commnented out below)
            // by value we mean pointer
            // GradeBook book2 = book;
            // the add commented out below will mean book will also get it
            // because the memory is what is being manipulated
            // book2.AddGrade(75);

            // Classes are reference types
            // Variables hold a pointer value

            // sometimes we talk about encapsulation as hiding something
            // like "lets encapsulate the data to the class"
        }
    }
}
