using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int>[] array = new Dictionary<char, int>[3];
            array[0] = new Dictionary<char, int>();
            array[1] = new Dictionary<char, int>();
            array[2] = new Dictionary<char, int>();

            array[0].Add('a',12);
            array[0].Add('b', 13);
            array[0].Add('c', 14);

            array[1].Add('a', 15);
            array[1].Add('v', 22);
            array[1].Add('b', 332);

            array[2].Add('c', 1315);
            array[2].Add('m', 222);
            array[2].Add('g', 3342);


            foreach (KeyValuePair<char,int> keyValue in array[0])
            {
               
            }
        }
    }
}
