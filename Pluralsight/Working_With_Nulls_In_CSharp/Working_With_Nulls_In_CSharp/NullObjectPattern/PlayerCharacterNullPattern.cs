using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp.NullObjectPattern
{
    class PlayerCharacterNullPattern
    {
        private readonly SpecialDefence _specialDefence;

        public PlayerCharacterNullPattern(SpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public void Hit(int damage)
        {
            #region Example 1 for null base interface

            //int damageReduction = 0;

            //if (_specialDefence != null)
            //{
            //    damageReduction = _specialDefence.CalculateDamageReduction(damage);
            //}

            //int totalDamageTaken = damage - damageReduction;

            #endregion

            #region Example 2 for null base interface

            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);

            #endregion

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health hasb been reduced by {totalDamageTaken} to {Health}");
        }
    }
}
