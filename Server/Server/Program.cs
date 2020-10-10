using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext info = new DataClasses1DataContext();
            //var result = from c in info.Books
            //                   where c.PRICE > 200
            //                   select new
            //                   {
            //                       ID = c.Id,
            //                       Name = c.Title,
            //                       Price = c.PRICE
            //                   };
            var result = info.Books.Where(c => c.PRICE > 200).Select(c => new { Id = c.Id, Name = c.Title, Price = c.PRICE });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
