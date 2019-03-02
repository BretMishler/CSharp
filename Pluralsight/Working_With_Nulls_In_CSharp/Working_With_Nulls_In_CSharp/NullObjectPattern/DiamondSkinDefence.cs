using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp.NullObjectPattern
{
    public class DiamondSkinDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 1;
        }
    }
}
