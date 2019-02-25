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

            Console.ReadLine();
        }
    }
}

