using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp
{
    class PlayerCharacter
    {
        public string Name { get; set; }
        //int and DateTime are structs -> Value type (F12 on them to see)
        public int DaysSinceLastLogin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public PlayerCharacter()
        {
            DateOfBirth = DateTime.MinValue; // magic number
            DaysSinceLastLogin = -1; // magic number
        }
    }
}
