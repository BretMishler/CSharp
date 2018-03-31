using System;
using Equality_and_Comparisons;

public static class Part8
{
    public static void Program()
    {
        string[] list = {
            "orange",
            "banana",
            "pear",
            "apple"
        };

        Array.Sort(list);

        foreach (var item in list)
            Console.WriteLine(item);

        Console.WriteLine();

        Food[] foodList1 = {
            new Food("orange", FoodGroup.Fruit),
            new Food("banana", FoodGroup.Fruit),
            new Food("pear", FoodGroup.Fruit),
            new Food("apple", FoodGroup.Fruit),
        };

        Array.Sort(foodList1, FoodNameComparer.Instance);

        foreach (var aFood in foodList1)
            Console.WriteLine(aFood);

        Console.WriteLine();

        Food[] foodList2 = {
            new Food("apple", FoodGroup.Fruit),
            new Food("pear", FoodGroup.Fruit),
            new CookedFood("baked", "apple", FoodGroup.Fruit)
        };
        SortAndShowList(foodList2);

        Food[] foodList3 = {
            new CookedFood("baked", "apple", FoodGroup.Fruit),
            new Food("pear", FoodGroup.Fruit),
            new Food("apple", FoodGroup.Fruit)
        };

        Console.WriteLine();
        SortAndShowList(foodList3);
    }

    static void SortAndShowList(Food[] list)
    {
        Array.Sort(list, FoodNameComparer.Instance);

        foreach (var item in list)
            Console.WriteLine(item);
    }
}