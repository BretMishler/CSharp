using System;
namespace Equality_and_Comparisons
{
    // sealed -> nothing else can derive from this
    public sealed class CookedFood : Food
    {
        // == and != already overriden in base but its good practice
        // to be explicit here as well
        public static bool operator ==(CookedFood x, CookedFood y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(CookedFood x, CookedFood y)
        {
            return !object.Equals(x, y);
        }

		public override bool Equals(object obj)
		{
            // Most equality logic is already in the base.Equals()
            // that this object inherits from (which is Food)
            if (!base.Equals(obj))
                return false;
            
            CookedFood rhs = (CookedFood)obj;
            return this._cookingMethod == rhs._cookingMethod;
		}

		public override int GetHashCode()
		{
            return base.GetHashCode() ^ this._cookingMethod.GetHashCode();
		}

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