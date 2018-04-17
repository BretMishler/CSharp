using System;
using System.Threading.Tasks;

// exercising Peterson's Solution for solving
// the critical section problem

public static class Peterson
{
    public static bool[] myFlags { get; set; }

    public static char turn;

    public static void Program()
    {
        myFlags = new bool[2];
        turn = new char();

        // these have to be true
        myFlags[0] = true;
        myFlags[1] = true;

        Task t1 = Task.Factory.StartNew(I);
        Task t2 = Task.Factory.StartNew(J);

        Task.WaitAll(t1, t2);
    }

    static void I()
    {
        Console.WriteLine("In I");
        int x = 0;

        do
        {
            myFlags[0] = true;
            turn = 'j';
            Console.WriteLine("I: About to hit while loop");
            while (myFlags[1] && turn == 'j') { };

            //critical section
            Console.WriteLine("I: critical section");

            myFlags[0] = false;

            //remainder section
            x++;
        } while (x < 5);

    }

    static void J()
    {
        Console.WriteLine("In J");
        int x = 0;

        do
        {
            myFlags[1] = true;
            turn = 'i';
            Console.WriteLine("J: About to hit while loop.");
            while (myFlags[0] && turn == 'i') { };
            //critical section
            Console.WriteLine("J: critical section");

            myFlags[1] = false;

            //remainder section
            x++;
        } while (x < 5);
    }
}