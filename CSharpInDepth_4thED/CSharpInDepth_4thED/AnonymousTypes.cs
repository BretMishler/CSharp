using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInDepth_4thED
{
    //If you need a particular data shape within a single method but nowhere else, creating a whole extra type is unnecessary
    internal class AnonymousTypes
    {
        public AnonymousTypes()
        {
            // Name and type are still checked by compiler
            var book = new { Title = "Lost in the Snoow", Author = "Holly Webb" };
            string title = book.Title;
            string author = book.Author;

            // or could use tuples for simpler temp data shape
            var bookTuple = (title: "Lost in the snow", author: "Holly Webb");
            Console.WriteLine(bookTuple.title);
            // Can replace anonymous types in some but not all cases

        }
    }
}
