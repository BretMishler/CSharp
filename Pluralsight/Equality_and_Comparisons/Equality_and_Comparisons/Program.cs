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
        // STRUCTS and ALL OTHER VALUE TYPES derive from System.ValueType, 
        // which derives from System.Object
        // BUT ValueType.Equals() overrides the virtual object.Equals()
        // The override for structs goes through all the fields of the
        // ValueType, calling Equals against each one until a field is !=
        //
        // Drawback: System.ValueType.Equals uses "reflection"
        // which means performances is pretty bad
        // BEST TO OVERRIDE EQUALS for your own value types 

        // REFERENCE
        // variables that are reference types are considered to be equal 
        // only if they refer to the same instance (same place in memory)

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
        // Equals. Which means for value types , no boxing! (since boxing to obj
        // would mean an attempt to do a reference check)
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

        // NATURAL COMPARING INTERFACES
        // IEquatable<T> for equality, great for val, not good for ref
        // IComparable<T> for comparisons

        // PLUGGED-IN COMPARING INTERFACES
        // IEqualityComprer<T> for equality
        // IComparer<T> for comparisons

        // DONT DO QUALITY COMPARISONS ON FLOATING POINTS
        // 6.0000000f == 6.0000001f => false  ....
        // x=5.05f, y=0.95f, 6 == (x+y) => false .... 

        // obj.Equals() is not type safe!
        // class Object { virtual bool Equals (object obj) }
        // the parameter will take any object and try to do comparisons on the
        // two! It wont warn ya and can cause a lot of bugs

        // string class has its own Equals() that overrides C#'s 
        // virtual obj.Equals()
        // string has several overrides, one where you can pass it a param of
        // type obj and it will make sure to do a ref compare, not value
        // string1.Equals((obj)string2)

        static void Main(string[] args)
        {
            //Part_1_2();
            //Part3();
            //Part4();
            //Part5();
            //Part6.Program();
            //Part7.Program();
            //Part8.Program();
            Part10.Program();
        }

        public static void Part5()
        {
            Food apple = new Food("apple", FoodGroup.Fruit);
            CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            CookedFood bakedApple = new CookedFood("baked", "apple", FoodGroup.Fruit);
            CookedFood stewedApple2 = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            Food apple2 = new Food("apple", FoodGroup.Fruit);

            DisplayWhetherEqual(apple, stewedApple);
            DisplayWhetherEqual(stewedApple, bakedApple);
            DisplayWhetherEqual(stewedApple, stewedApple2);
            DisplayWhetherEqual(apple, apple2);
            DisplayWhetherEqual(apple, apple);
        }

        //public enum FoodGroup { Meat, Fruit, Vegetables, Sweets}

        public struct FoodItem : IEquatable<FoodItem>
        {
            private readonly string _name;
            private readonly FoodGroup _group;

            // implemented by VS if you ask it to with right-click
            // interface part
            public bool Equals(FoodItem other)
            {
                // == does value equality for string and enums
                return this._name == other.Name && this._group == other._group;
            }

            // because of boxing and casting, IEquatable<T>.Equals() will still
            // be more effecient
            public override bool Equals(object obj)
            {
                if (obj is FoodItem)
                    return Equals((FoodItem)obj);
                else
                    return false;
            }

            public static bool operator ==(FoodItem lhs, FoodItem rhs)
            {
                // can also do return !(lhs == rhs);
                return lhs.Equals(rhs);
            }

            public static bool operator !=(FoodItem lhs, FoodItem rhs)
            {
                return !lhs.Equals(rhs);
            }

			public override int GetHashCode()
			{
                // Microsoft has already implemented GetHasCode()
                // for standard .NET types
                return _name.GetHashCode() ^ _group.GetHashCode();
                // ^ is XOR (exclusive OR)
			}

            public string Name { get { return _name; }}
            public FoodGroup Group { get { return _group; }}

            public FoodItem(string name, FoodGroup group)
            {
                this._name = name;
                this._group = group;
            }

			public override string ToString()
			{
                return _name;
			}
		}

        static void Part4()
        {
            FoodItem banana = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem banana2 = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem chocolate = new FoodItem("banana", FoodGroup.Sweets);

            Console.WriteLine(
                "banana   == banana2:   " + (banana == banana2));
            Console.WriteLine(
                "banana2   == chocolate:   " + (banana2 == chocolate));
            Console.WriteLine(
                "chocolate   == banana2:   " + (chocolate == banana));
            
        }

        static void Part3()
        {
            Console.WriteLine("\n== for Integers");
            Console.WriteLine("Operator: " + AreIntsEqualOp(3, 3));
            Console.WriteLine("Method  : " + AreIntsEqualMethod(3, 3));

            Console.WriteLine("\n== for Strings");
            string str1 = "Click me now!";
            string str2 = string.Copy(str1);
            Console.WriteLine("Reference: " + ReferenceEquals(str1, str2));
            Console.WriteLine("Operator : " + AreStringsEqualOp(str1, str2));
            Console.WriteLine("Method   : " + AreStringsEqualMethod(str1, str2));

            // point here w/ strings is that the equality operator indeeds
            // tests the value, not reference, just as object.Equals does

            Tuple<int, int> tuple1 = Tuple.Create(1, 3);
            Tuple<int, int> tuple2 = Tuple.Create(1, 3);

            Console.WriteLine("\n== for Tuples");
            Console.WriteLine("Reference: " +
                             ReferenceEquals(tuple1, tuple2));
            Console.WriteLine("Method   : " + tuple1.Equals(tuple2));
            Console.WriteLine("Operator : " + (tuple1 == tuple2));

            // tuples are a ref type!
            // Microsoft overrides the .Equals to provide a value equality
            // symantics. But they didnt write an overload for ==
            // Lecturer agrees that this is VERY confusing

            string str3 = "apple";
            string str4 = string.Copy(str3);

            Console.WriteLine("\n== Inheritence doesnt always work as expected.");
            Console.WriteLine("STRINGS");
            Console.WriteLine("Reference : " + ReferenceEquals(str3, str4));
            Console.WriteLine("Method    : " + str3.Equals(str4));
            Console.WriteLine("Operator  : " + (str1 == str2));
            Console.WriteLine("Static    : " + object.Equals(str1, str2));

            object obj1 = "apple";
            object obj2 = string.Copy((string)obj1);

            Console.WriteLine("OBJECTS (copying obj1 with cast(string) to ojb2)");
            Console.WriteLine("Reference : " + ReferenceEquals(obj1, obj2));
            // obj.Equals overrides for string implementation
            Console.WriteLine("Method    : " + obj1.Equals(obj2));
            // == for obj is static so no override
            Console.WriteLine("Operator  : " + (obj1 == obj2));
            Console.WriteLine("Static    : " + object.Equals(obj1, obj2));

            // Equality operator is not virtual
        }

        static void Part_1_2()
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

        // This is a good example of good OOP. 
        // This method takes any FOOD TYPE
        static void DisplayWhetherEqual(Food food1, Food food2)
        {
            if (food1 == food2)
            {
                Console.WriteLine(string.Format("{0,12} == {1}", food1, food2));
            }
            else
                Console.WriteLine(string.Format("{0,12} != {1}", food1, food2));
        }
    }
} 
