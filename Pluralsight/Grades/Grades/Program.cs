using System;
using System.IO;

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
// changing the size of an array may be an expensive operationt

// METHODS
// return type of a method is not part of the method signature

// FIELDS
// fields are variables of a class
// honestly just seems like what we'd call "properties"
// Ahh its actually similiar. Unlike a field, a property has a special syntax
// for what happens when someone reads/writes a fields
// field:     private string _name;
// prop:      public string Name{ get {return _name; } set {... }}
// prop is capital w/ get/set accessors

// PROPERTIES
// c# naming guide lines tell us to capitalize property names (and method names)
// know its a prop because it has get and set accessors
// GET accessor returns a value of the TYPE of the property (like string)
// SET accessor- code envoked anytime someoen tries to write a value INSIDE
// this property, think of it like a paramter inside the set accessor

// EVENTS
// allow objects announce to listeners that something happened (like a click)
// can have multipe subscripers listening to an event, they can be independent
// this is all done through the magic of DELEGATES

// DELEGATES
// imagine want to declare a variable that references a method
// that means you have a variable that encapsulates executable code
// a DELEGATE is a type, in the same way that we use the CLASS keyword to create
// a type or the STRUCT keyword to create a type.
// delegate is a type for referencing methods
// looks like a method definition
// public delegate void Writer(string message);
// name of this TYPE is Writer
// imagine class called Logger w/ method called void WriteMessage(String message)
// EXAMPLE
// Logger logger = new Logger();
// Writer writer = new Writer(logger.WriteMessage); // notice didnt pass arg
// writer("Success!!");

// EVENTS (part 2)
// Events are based on and use delegates

// TRY CATCH
// try { ComputeStatistics(); }
// catch(DivideByZeroExceptione ex){ ... }
// how this works is that if an exception is thrown inside ComputeStatistics,
// the program will go looking for the NEAREST catch with the exception thrown
// in this case, IF a DivideByZeroException occurs, then code inside will be executed
// if not, then it's uncaught. 
// can tie up more than one exception, chain catch blocks

// CHAINING CATCH BLOCKS
// try { ... }
// catch(DivideByZeroException ex){}
// catch(Exception ex){}
// Exception catches everything
// IF YOU HANDLE AN EXCEPTION THAT MAYBE YOU SHOULDNT HAVE HANDLED...
// keep in mind that the PROGRAM WILL NOT TERMINATE
// so be careful

// FINALLY
// executes even when control jumps out of scope
// good for cleaning up resources and such

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //behind the scenes a constructor method is being invoked so () required
            GradeBook book = new GradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            // cw tab tab for console.writeLine();
            //Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            //WriteResult("Params Example", stats.LowestGrade, 2, 3, 4);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch(NullReferenceException ex)
            //{
            //    Console.WriteLine("Something went wrong!");
            //}

            // += to add up delegates onto this or esle only the last
            // assigned delegate will be in effect
            // can also use -= if you want to remove a delegate
            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            // prefered version
            //book.NameChanged += OnNameChanged;

            //book.Name = "Bret's Grade Book";
            //book.Name = "Grade Book";
            //book.Name = null;
        }

        //static void OnNameChanged(object send, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
            // there are other format options like {1:C}
        }

        //example of passing in multiple items
        //static void WriteResult(string description, params float[] result)
        //{
        //    foreach(var r in result) {
        //        Console.WriteLine(description + ": " + r);
        //    }
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}", description, result);
            // there are other format options like {1:C}
        }
    }
}