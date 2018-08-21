using System;
using System.Collections.Generic;

namespace RandomStuff
{
    class Program
    {

        static void Main(string[] args)
        {
            //HashTableDemo.Program();
            var book = new Dictionary<string, int>();
            var x = new Toot("h", 4);
            book.Add(x.key, x.item);
            var y = book[x.key];
        }
    }

    class Toot
    {
        public string key;
        public int item;

        public Toot(string k, int i)
        {
        key = k;
        item = i;

        }
    }
}
