﻿using System;

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

        static void Main(string[] args)
        {
            string banana = "banana";
            string banana2 = string.Copy(banana);

            Console.WriteLine(banana);
            Console.WriteLine(banana2);
            Console.WriteLine(ReferenceEquals(banana, banana2));
            Console.WriteLine(banana.Equals((object)banana2));
        }
    }
}
