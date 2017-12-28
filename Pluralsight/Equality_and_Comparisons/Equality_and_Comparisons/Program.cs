using System;

namespace Equality_and_Comparisons
{
    class Program
    {
        // == is the C# equality operator, not provided by .NET
        // .NET has no concept of operators

        static void Main(string[] args)
        {
            Food banana = new Food("banana");
            Food banana2 = new Food("banana");
            Food chocolate = new Food("chocolate");

            Console.WriteLine(banana.Equals(chocolate));
            Console.WriteLine(banana.Equals(banana2));
        }
    }
}
