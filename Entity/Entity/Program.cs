using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Program
    {
        static void AddAuthor(Authors author)
        {
            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                Console.WriteLine("New author added: " + author.Lastname);
            }
        }
        static void GetAllAuthors()
        {
            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                var au = db.Authors.ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.Firstname + " " + a.Lastname);
                }
            }
        }

        static Authors GetAuthorByName(string fname)
        {
            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                var author = (from s in db.Authors
                              where s.Firstname == fname
                              select s).FirstOrDefault<Authors>();
                return author;
            }
        }
        static void Main(string[] args)
        {
            //Authors author = new Authors
            //{
            //    Firstname = "Mikhail",
            //    Lastname = "Bulgakov"
            //};
            //AddAuthor(author);
            GetAllAuthors();
        }
    }
}
