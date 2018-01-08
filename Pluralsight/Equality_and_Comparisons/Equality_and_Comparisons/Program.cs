using System;

namespace Equality_and_Comparisons
{
    class Program
    {
        // == is the C# equality operator, not provided by .NET
        // .NET has no concept of operators

        // STRUCT
        // by default, object.Equals() compares values for structs
        // instead of by ref for classes
        //
        // Derive from System.ValueType, which derives from System.Object
        // BUT ValueType.Equals() overrides Object.Equals()
        // The override for structs goes through all the fields of the
        // ValueType, calling Equals against each one until a field is !=
        //
        // Drawback: System.ValueType.Equals uses "reflection"
        // which means performances is pretty bad
        // BEST TO OVERRIDE EQUALS for your own value types 

        // REFERENCE
        // variables that are reference types are considered to be equal 
        // only if they refer to the same instance

        // OBJECTS
        // have two static types. Equals and ReferenceEquals
        // and iEquatable of <T> interface   

        // STATIC
        // static methods are never overridable 

        // BOXING
        // process of converting a value type to the type [object]
        // or to any interface by this value type
        // When the CLR boxes a value type, it wraps the value
        // inside a System.Object and stores it on the managed heap

        // IEquatable<T>
        // can be exposed to any type that wants to provide a strongly-typed
        // Equals. Which means for value types , no boxing!
        // EXTREMELY USEFUL FOR VALUE TYPES
        // Not so useful for reference types

        // Make an int x = whatever number.
        // if you do 
        // x.Equals(), note two Equals method
        // 1. takes an Object (which is the overriden object.Equals method)
        // 2. takes an int as a param (which is Int implementation of
        // IEquatqable<int>)
        // because in both, we pass an int, so the compiler will see the 
        // strongly-typed IEquatable<int> method has the best signature match
        // 

        // GOOD PRACTICE FOR OVERRIDE EQUALS
        // if you want to implement the IEquatable<T> interface, then you
        // should override object.Equals to do exactly the same thing as your
        // interface method does

        // NOTES
        // Strings, delegates, and tuples override object.Equals() in order to
        // provide value equality
        // Object also provides a static equals method for either param to be
        // null
        // iEquatable<T> to provide a strongly-typed Equals method that avoids
        // boxing for value types

        static void Main(string[] args)
        {
            int three = 3;
            int threeAgain = 3;
            int four = 4;
            //test

            Console.WriteLine(three.Equals(threeAgain));
            Console.WriteLine(three.Equals(four));

            // if we dont do string.Equals(object)string, compiler would have
            // picked strongly typed IEquatable<string>, aka
            // string's implementation of IEquatable<T>

            Console.WriteLine("\n== for Integers");
            Console.WriteLine("Operator: " + AreIntsEqualOp(3, 3));
            Console.WriteLine("Method: " + AreIntsEqualMethod(3, 3));

            Console.WriteLine("\n== for Strings");
            string str1 = "Click me now!";
            string str2 = string.Copy(str1);
            Console.WriteLine("Reference: " + ReferenceEquals(str1, str2));
            Console.WriteLine("Operator: " + AreStringsEqualOp(str1, str2));
            Console.WriteLine("Method: " + AreStringsEqualMethod(str1, str2));

            // point here w/ strings is that the equality operator indeeds
            // tests the value, not reference, just as object.Equals does
        }
         
        static bool AreIntsEqualOp(int x, int y)
        {
            return x == y;
        }

        static bool AreIntsEqualMethod(int x, int y)
        {
            return x.Equals(y);
        }

        static bool AreStringsEqualOp(string x, string y)
        {
            return x == y;
        }

        static bool AreStringsEqualMethod(string x, string y)
        {
            return x.Equals(y);
        }
    }
} 
