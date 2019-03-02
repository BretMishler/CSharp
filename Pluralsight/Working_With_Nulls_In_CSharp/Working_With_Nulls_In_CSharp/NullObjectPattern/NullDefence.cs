using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp.NullObjectPattern
{
    class NullDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 0; // no operation / "do nothing" behavior
        }
    }
}
