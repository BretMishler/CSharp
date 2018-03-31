using System;
using System.Collections.Generic;

namespace Equality_and_Comparisons
{
    public class FoodNameComparer : Comparer<Food>
    {
        private static FoodNameComparer _instance = new FoodNameComparer();

        public static FoodNameComparer Instance { get { return _instance; } }

        private FoodNameComparer() { }

        public override int Compare(Food x, Food y)
        {
            // C# convention:
            // null == null
            //      (Compare(null, null) == 0)
            if (x == null && y == null)
                return 0;

            // C# convention:
            // null < (anything else)
            //      (Compare(null, y)
            if (x == null)
                return -1;

            // C# convention:
            // null < (anything else)
            //      (Compare(x, null) > 0)
            if (y == null)
                return 1;
            
            return string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);
        }
    }
}
