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

        static void Main(string[] args)
        {
            int three = 3;
            int threeAgain = 3;
            int four = 4;

            Console.WriteLine(three.Equals(threeAgain));
            Console.WriteLine(three.Equals(four));
        }
    }
}
