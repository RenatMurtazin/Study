using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_задач
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        
        public Book(string name,string author)
        {
            Name = name;
            Author = author;
        }
    }
    class Program
    {
        public static int IndexOf<T>(LinkedList<T> list, T item)
        {
            var count = 0;
            for (var node = list.First; node != null; node = node.Next, count++)
            {
                if (item.Equals(node.Value))
                    return count;
            }
            return -1;
        }
        static void ListSort2()
        {
            LinkedList<int> numbers = new LinkedList<int>();
            numbers.AddLast(1);
            numbers.AddLast(-3);
            numbers.AddLast(4);
            numbers.AddLast(-5);
            numbers = new LinkedList<int>(numbers.OrderBy(x => IndexOf<int>(numbers, x) % 2 == 0));
            foreach (var temp in numbers)
            {
                Console.Write(temp);
            }
        }
        static void ListSort()
        {
            LinkedList<int> numbers = new LinkedList<int>();
            numbers.AddLast(1);
            numbers.AddLast(2);
            numbers.AddLast(3);
            numbers = new LinkedList<int>(numbers.OrderByDescending(x => x));
            LinkedList<int> numbers2 = new LinkedList<int>();
            foreach(var temp in numbers)
            {
                Console.Write(temp);
            }
            Console.WriteLine();
            numbers2.AddLast(4);
            numbers2.AddLast(5);
            numbers2.AddLast(6);
            numbers2 = new LinkedList<int>(numbers2.OrderByDescending(x => x));
            foreach (var temp in numbers2)
            {
                Console.Write(temp);
            }
            Console.WriteLine();
            foreach(var temp in numbers2)
            {
                numbers.AddLast(temp);
            }
            numbers = new LinkedList<int>(numbers.OrderByDescending(x => x));
            foreach(var temp in numbers)
            {
                Console.Write(temp);
            }
            Console.WriteLine();
        }
        static void AddBook() 
        {

            LinkedList<Book> books = new LinkedList<Book>();
            var book1 = new Book("dfc", "sasasas");
            var book2 = new Book("fdfdfdf", "aasass");
            var book3 = new Book("dfdfdf", "ccxcxc");
            books.AddLast(book1);
            books.AddLast(book2);
            books.AddLast(book3);
            books = new LinkedList<Book> (books.OrderBy(x => x.Name));
            foreach (var temp in books)
            {
                Console.Write($" {temp.Name} ");
            }
            Console.WriteLine();
            var book4 = new Book("assas", "rrewa");
            books.AddLast(book4);
            books = new LinkedList<Book>(books.OrderBy(x => x.Name));
            foreach (var temp in books)
            {
                Console.Write($" {temp.Name} ");
            }
        }
        
        static void Main(string[] args)
        {
            AddBook();
            Console.WriteLine();
            ListSort();
            Console.ReadKey();
            ListSort2();
        }
    }
}
