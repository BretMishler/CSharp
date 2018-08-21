using System;
using System.Collections.Generic;

namespace RandomStuff
{
    public class ArrayPractice
    {
        public int demo;

        public static void Program()
        {
            int[] quad = new int[4];
            int[] tri = { 1, 2, 3 };
            int[] uno = new int[1] { 1 };
            int[] wtvr = new int[] { 3, 8 };
            int[,] dbl = new int[2, 4];
            dbl[0, 1] = 5;
            tri.CopyTo(quad, 0);
            Console.WriteLine(tri);
            Console.WriteLine(quad);

            List<string> sea = new List<string>() { "hello" };
            sea.Add("hi");

            foreach (var word in sea)
            {
                Console.WriteLine(word);
            }
        }

    }
}
