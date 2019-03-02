using System;
using Working_With_Nulls_In_CSharp.NullObjectPattern;

namespace Working_With_Nulls_In_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Working With Null Ref Values

            //PlayerCharacter player = new PlayerCharacter();
            //player.DaysSinceLastLogin = 42;
            //// use null conditional operator
            //// if player not null, go into its property
            //int days = player?.DaysSinceLastLogin ?? -1;
            //Console.WriteLine(days);

            //PlayerCharacter playerTwo = null;
            //days = playerTwo?.DaysSinceLastLogin ?? -1;
            //Console.WriteLine(days);


            //PlayerCharacter[] players = new PlayerCharacter[3]
            //{
            //    new PlayerCharacter {Name = "Sarah"},
            //    new PlayerCharacter(), // Name = null
            //    null //
            //};

            //// PlayerCharacter[] players = null;

            //// ?[ is accessing the element
            //// ?. is accessing the property
            //string p1 = players?[0]?.Name;
            //string p2 = players?[1]?.Name;
            //string p3 = players?[2]?.Name;
            //Console.ReadLine();

            #endregion

            #region Null Object Pattern

            PlayerCharacterNullPattern sarah = new PlayerCharacterNullPattern(new DiamondSkinDefence())
            {
                Name = "Sarah"
            };

            PlayerCharacterNullPattern amrit = new PlayerCharacterNullPattern(new IronBonesDefence())
            {
                Name = "Amrit"
            };

            PlayerCharacterNullPattern gentry = new PlayerCharacterNullPattern(SpecialDefence.Null)
            {
                Name = "Gentry"
            };

            sarah.Hit(10);
            amrit.Hit(10);
            gentry.Hit(10);

            Console.ReadLine();

            #endregion

        }
    }
}

