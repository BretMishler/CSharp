using System;
using System.Globalization;
using System.Threading;

public static class Part7
{
    public static void Program()
    {
        //method is specific to string
        int result = string.Compare("lemon", "lime", StringComparison.Ordinal);
        Console.WriteLine("Compare result is " + result);
        result = string.Compare("lemon", "LEMON", StringComparison.Ordinal);
        Console.WriteLine("Compare result is " + result);

        Console.WriteLine("Current culture is " + Thread.CurrentThread.CurrentCulture);
        string str1 = "apple";
        string str2 = "PINEAPPLE";
        DisplayAllComparisons(str1, str2);

        Console.WriteLine();

        string str3 = "Stra\u00dfe";
        string str4 = "Strasse";
        DisplayAllComparisons(str3, str4);

        string str5 = "erkl\u00e4ren";
        string str6 = "erkla\u0308ren";
        DisplayAllComparisons(str5, str6);

        Console.WriteLine();

        bool areEqual = string.Equals("Apple", "Pineapple", 
                                      StringComparison.CurrentCultureIgnoreCase);

        // To do an equals for which there is no Equals() method;
        int cmpResult = string.Compare("Apple", "Pineapple",
                                      CultureInfo.GetCultureInfo("fr-FR"),
                                       CompareOptions.IgnoreSymbols);
        areEqual = (cmpResult == 0);

        // case-sensitive ordinal:
        areEqual = ("Apple" == "Pineapple");
        areEqual = "Apple".Equals("Pineapple");

        Console.WriteLine();

        string str7 = "Apple";
        string str8 = "Ap" + "ple";
        Console.WriteLine(string.Format("strings are {0} and {1}", str7, str8));
        Console.WriteLine(str7 == str8);
        // this is true because C# compiler does str8's concatination at
        // compile time (instead of run time)
        // and since strings are IMMUTABLE, it sees "Apple" already exists in
        // str7 and so sets the variables to point in the same location in mem

        // so hardcoded strings MIGHT compile to a single instance
        Console.WriteLine(ReferenceEquals(str7, str8));
    }

    static void DisplayAllComparisons(string str1, string str2)
    {
        DisplayComparison(str1, str2, StringComparison.Ordinal);
        DisplayComparison(str1, str2, StringComparison.OrdinalIgnoreCase);
        DisplayComparison(str1, str2, StringComparison.InvariantCulture);
        DisplayComparison(str1, str2, StringComparison.InvariantCultureIgnoreCase);
        DisplayComparison(str1, str2, StringComparison.CurrentCulture);
        DisplayComparison(str1, str2, StringComparison.CurrentCultureIgnoreCase);
    }

    static void DisplayComparison(string str1, string str2, 
                                  StringComparison comparison)
    {
        int result = string.Compare(str1, str2, comparison);
        Console.WriteLine("{0} {1} {2}    ({3}, {4})", str1,
                          GetCompareSymbol(result), str2, result, comparison);        
    }

    static string GetCompareSymbol(int compareResult)
    {
        if (compareResult == 0)
            return "==";
        else if (compareResult < 0)
            return "< ";
        else
            return "> ";
    }
}