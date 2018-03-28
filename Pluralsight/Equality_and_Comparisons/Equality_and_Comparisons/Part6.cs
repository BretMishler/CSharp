using System;

public static class Part6
{
    public static void Program()
    {
        string apple = "apple";
        string pear = "pear";

        //Three possible outcomes (==, <, >)
        //Console.WriteLine(apple.CompareTo(pear));
        //Console.WriteLine(pear.CompareTo(apple));
        //Console.WriteLine(apple.CompareTo(apple));

        DisplayOrder(apple, pear);
        DisplayOrder(pear, apple);
        DisplayOrder(apple, apple);

        // all primitives inherit from IComparable<T>
        // so our function works
        DisplayOrder(3, 4);
        DisplayOrder(4, 3);
        DisplayOrder(3, 3);

        //in this demo, CalorieCount has an obvious, "natural" comparison
        CalorieCount cal300 = new CalorieCount(300);
        CalorieCount cal400 = new CalorieCount(400);

        DisplayOrder(cal300, cal400);
        DisplayOrder(cal400, cal300);
        DisplayOrder(cal300, cal300);

        if (cal300 < cal400)
            Console.WriteLine("cal300 < call400");

        // if you overload comparison operators
        // you should
        // overload equality operators
        if (cal300 == cal400)
            Console.WriteLine("cal300 == cal400");
    }

    // where T must implement the IComparable interface
    static void DisplayOrder<T>(T x, T y) where T : IComparable<T>
    {
        int result = x.CompareTo(y);
        if (result == 0)
            Console.WriteLine("{0,12} = {1}", x, y);
        else if (result > 0)
            Console.WriteLine("{0,12} > {1}", x, y);
        else
            Console.WriteLine("{0,12} < {1}", x, y);
    }

    public struct CalorieCount : IComparable<CalorieCount>, IEquatable<CalorieCount>, IComparable
    {
        private float _value;

        public float Value { get { return _value; } }

        public CalorieCount(float value)
        {
            this._value = value;
        }

		public override string ToString()
		{
            return _value + " cal";
		}

        public int CompareTo(CalorieCount other)
        {
            return this._value.CompareTo(other._value);
        }

        public bool Equals(CalorieCount other)
        {
            return _value == other._value;
        }

		public override bool Equals(object obj)
		{
            if (obj == null)
                return false;
            if (!(obj is CalorieCount))
                return false;
            return _value == ((CalorieCount)obj)._value;
		}

		public override int GetHashCode()
		{
            return _value.GetHashCode();
		}

        // IComparable, not type safe
		public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (!(obj is CalorieCount))
                throw new ArgumentException("Expected CalorieCount Instance", "obj");
            return CompareTo((CalorieCount)obj);
        }

        public static bool operator ==(CalorieCount x, CalorieCount y)
        {
            return x._value == y._value;
        }

        public static bool operator !=(CalorieCount x, CalorieCount y)
        {
            return x._value != y._value;
        }

        public static bool operator <(CalorieCount x, CalorieCount y)
        {
            return x._value < y._value;
        }

        public static bool operator <=(CalorieCount x, CalorieCount y)
        {
            return x._value <= y._value;
        }

        public static bool operator >(CalorieCount x, CalorieCount y)
        {
            return x._value > y._value;
        }

        public static bool operator >=(CalorieCount x, CalorieCount y)
        {
            return x._value >= y._value;
        }
	}
}