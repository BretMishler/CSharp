using System;

namespace Equality_and_Comparisons
{
    class Program
    {
        // == is the C# equality operator, not provided by .NET
        // .NET has no concept of operators

        static void Main(string[] args)
        {
            string banana = "banana";
            string banana2 = string.Copy(banana);

            Console.WriteLine(banana);
            Console.WriteLine(banana2);
            Console.WriteLine(banana.Equals((object)banana2));
        }
    }
}
