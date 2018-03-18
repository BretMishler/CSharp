using System;

//used in part 5
namespace Equality_and_Comparisons
{
    public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

    public class Food
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get { return _name; }}

        public FoodGroup Group { get { return _group;  } }

        public Food(string name, FoodGroup group)
        {
            this._name = name;
            this._group = group;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
