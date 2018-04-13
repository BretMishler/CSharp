using System;
using System.Collections;

public static class Part10
{
    public static void Program()
    {
        string[] arr1 = { "apple", "orange", "pineapple" };
        string[] arr2 = { "apple", "orange", "pineapple" };

        // will be false because arrays are ref type
        Console.WriteLine(arr1 == arr2);
        Console.WriteLine(arr1.Equals(arr2));

        Console.WriteLine();

        var arrayEq = (IStructuralEquatable)arr1;
        bool structEqual = arrayEq.Equals(arr2, StringComparer.Ordinal);
        Console.WriteLine(structEqual);

        arr2[2] = "Pineapple";
        structEqual = arrayEq.Equals(arr2, StringComparer.Ordinal);
        Console.WriteLine(structEqual);

        structEqual = arrayEq.Equals(arr2, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(structEqual);

        Console.WriteLine();
        Console.WriteLine();

        var arrayComp = (IStructuralComparable)arr1;
        int structComp = arrayComp.CompareTo(arr2, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(structComp);
    }
}