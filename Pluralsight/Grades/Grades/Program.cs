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

            // TYPES
            // value types are gen faster to allocate in mem than ref types
            // value types are typically immutable
            // doesnt mean we cant change x, just means we cannot change 4
            // any class is a ref type

            // STRUCT
            // is a value type as a substitue for class
            // write a class by default; structs are very special cases
            // use it to represent complex #'s, a point in 3-d, etc.
            // good for representing small, single dataq

            // ENUM
            // create only spacific numerical values
            // short for enumeration
            // a way to create a value type
            // instead of if(employee.Role == 2)
            // do if(employee.Role == PayrollType.Salaried)
            // where PayrollType is an enum

            //String is a reference type

            // REF and OUT
            // rarely will, if ever, use these keyword
            // out assumes youre producing an ouput through this param
            // so C# compiler requires you changing incoming OUT param
            // foo(out int number)

            // IMMUTABILITY
            // value types are usually immutable
            // primitives are immutable
            // 4 is immutable. x is not :)
            // DateTime date = new DAteTime(2002, 8, 11);
            // date.AddDays(1);
            // once created, value cannot change
            // AddDays will never change the underlying datetime value
            // what it does is return a new DateTime instance
            // so you have to actually assign it
            // DateTime date2 = date.AddDays(1);
            // same idea w/ strings
            // string IS A REFERENCE TYPE but acts like a value type
            // a string is immutable

            // keep in mind that methods may return a new value or instance
            // as opposed to changing the value of the class

            // ARRAYS
            // manage a collection of variables
            // changing the size of an array may be an expensive operation
        }
    }
}