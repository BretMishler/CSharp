using System;

namespace Working_With_Nulls_In_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            PlayerCharacter player = new PlayerCharacter();
            player.DaysSinceLastLogin = 42;
            // use null conditional operator
            // if player not null, go into its property
            int days = player?.DaysSinceLastLogin ?? -1;
            Console.WriteLine(days);

            PlayerCharacter playerTwo = null;
            days = playerTwo?.DaysSinceLastLogin ?? -1;
            Console.WriteLine(days);


            PlayerCharacter[] players = new PlayerCharacter[3]
            {
                new PlayerCharacter {Name = "Sarah"},
                new PlayerCharacter(), // Name = null
                null //
            };

            // PlayerCharacter[] players = null;

            // ?[ is accessing the element
            // ?. is accessing the property
            string p1 = players?[0]?.Name;
            string p2 = players?[1]?.Name;
            string p3 = players?[2]?.Name;

            Console.ReadLine();
        }
    }
}

