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
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                Console.WriteLine("Player name is null or white space.");
            }
            else
                Console.WriteLine(player.Name);

            #region Magic Number Technique (worse)
            //// DaysSinceLastLogin could be null if they just created an account and have never logged in
            //// so we'll choose an arbitrary value as a "magic number" for nulls
            //// though this technique is not recommended
            //if (player.DaysSinceLastLogin == -1)
            //    Console.WriteLine("No value for DaysSinceLastLogin");
            //else
            //    Console.WriteLine(player.DaysSinceLastLogin);

            //// choosing an arbitrary value -- this time a constant
            //if (player.DateOfBirth == DateTime.MinValue)
            //    Console.WriteLine("No DateOfBirth specified");
            //else
            //    Console.WriteLine(player.DateOfBirth);
            #endregion

            #region Nullable<T> Technique (better)



            //if (player.DaysSinceLastLogin.HasValue)
            //    Console.WriteLine(player.DaysSinceLastLogin.Value);
            //else
            //    Console.WriteLine("No value for DaysSinceLastLogin");

            //int days = player.DaysSinceLastLogin.GetValueOrDefault(-1);

            //int days = player.DaysSinceLastLogin.HasValue ? player.DaysSinceLastLogin.Value : -1;

            int days = player.DaysSinceLastLogin ?? -1;

            Console.WriteLine($"{days} days since last login");

            // choosing an arbitrary value -- this time a constant
            if (player.DateOfBirth == null)
                Console.WriteLine("No DateOfBirth specified");
            else
                Console.WriteLine(player.DateOfBirth);

            #endregion

            if (player.IsNoob == null)
            {
                Console.WriteLine("Player newbie status is unknown.");
            }
            else if(player.IsNoob == true)
            {
                Console.WriteLine("Player is a newbie");
            }
            else
            {
                Console.WriteLine("Player is experienced");
            }
        }
    }
}
