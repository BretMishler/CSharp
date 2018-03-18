using System;
namespace Equality_and_Comparisons
{
    // sealed -> nothing else can derive from this
    public sealed class CookedFood : Food
    {
        private string _cookingMethod;

        public string CookingMethod { get { return _cookingMethod; } }

        public CookedFood(string cookingMethod, string name, FoodGroup group)
            : base(name, group)
        {
            this._cookingMethod = cookingMethod;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", _cookingMethod, Name);
        }
    }
}