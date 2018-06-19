using System;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            #region LINQ Query Operators
            var cheapBooks1 = from b in books
                              where b.Price < 10
                              orderby b.Title
                              select b.Title;
            #endregion

            #region LINQ Extension Methods
            var cheapBooks2 = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title)
                                .ToList();

            foreach (var book in cheapBooks2)
                Console.WriteLine(book);


            #endregion
        }
    }
}
