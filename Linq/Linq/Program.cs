using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public override string ToString()
            {
                return $"{Name} {Age} {City}";
            }
        }

        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
            {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 47, City = "Moscow" },
                new Person(){ Name = "Michael", Age = 26, City = "London" },
                new Person(){ Name = "Sofia", Age = 34, City = "Paris" }
            };

            var result = from a in person
                         where a.Age >25
                         select a;
            var result2 = from b in person
                          where b.City != "Kyiv"
                          select b;
            var result3 = from c in person
                          where c.City == "Kyiv"
                          select c.Name;
            var result4 = from d in person
                          where d.Age > 35
                          where d.Name == "Sergey"
                          select d;
            var result5 = from e in person
                          where e.City == "Moscow"
                          select e;

            Console.WriteLine("\nPersons older than 25:");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total count:" + result.Count());

            Console.WriteLine("\nPersons not living in Kyiv:");
            foreach (var item in result2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total count:" + result2.Count());

            Console.WriteLine("\nPersons living in Kyiv:");
            foreach (var item in result3)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total count:" + result3.Count());

            Console.WriteLine("\nPersons older than 35 named Sergey:");
            foreach (var item in result4)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total count:" + result4.Count());

            Console.WriteLine("\nPersons living in Moscow:");
            foreach (var item in result5)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total count:" + result5.Count());
        }
    }
}
