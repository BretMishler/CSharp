using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Nulls_In_CSharp
{
    class PlayerDisplayer
    {
        /// <summary>
        /// Output player details
        /// </summary>
        /// <param name="player"></param>
        public static void Write(PlayerCharacter player)
        {
            Console.WriteLine(player.Name);

            // DaysSinceLastLogin could be null if they just created an account and have never logged in
            // so we'll choose an arbitrary value as a "magic number" for nulls
            // though this technique is not recommended
            if (player.DaysSinceLastLogin == -1)
                Console.WriteLine("No value for DaysSinceLastLogin");
            else
                Console.WriteLine(player.DaysSinceLastLogin);

            // choosing an arbitrary value -- this time a constant
            if (player.DateOfBirth == DateTime.MinValue)
                Console.WriteLine("No DateOfBirth specified");
            else
                Console.WriteLine(player.DateOfBirth);



        }
    }
}
