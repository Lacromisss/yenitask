using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp45
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name} AuthorName:{AuthorName} Id: {Id} Price: {Price} ");
        }

    }
}