using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp
{
    class PlayerCharacter
    {
        public string Name { get; set; }


        #region Magic Number Technique (worse)
        //int and DateTime are structs -> Value type (F12 on them to see)
        //public int DaysSinceLastLogin { get; set; }
        //public DateTime DateOfBirth { get; set; }

        //public PlayerCharacter()
        //{
        //    DateOfBirth = DateTime.MinValue; // magic number
        //    DaysSinceLastLogin = -1; // magic number
        //}
        #endregion

        #region Nullable<T> Technique (better)
        //Nullable<T> = T?
        public Nullable<int> DaysSinceLastLogin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsNoob { get; set; }

        //CONSTRUCTOR - dont need it because default value of 
        // Nullable<T> is Null
        #endregion

    }
}
