using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Тест
{
    class CreateTest
    {
        public string path;

        public CreateTest(string path) { this.path = path;  }
        public void Test(long count)
        {
            var rand = new Random();

            string str = "";
            for (int i = 0; i < count; i++)
            {
                str += rand.Next(10000, 100000000) + ",";
            }
            File.AppendAllText(path, str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = @"D:\Input\Test";
            for (int i = 0; i < 100; i++)
            {
                string path = str + i + ".txt";
                var test = new CreateTest(path);
                test.Test(new Random().Next(100, 10000));
            }
            Console.ReadKey();
        }
    }
}
