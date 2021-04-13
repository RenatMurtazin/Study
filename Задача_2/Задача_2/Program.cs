using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_2
{

    class Program
    {
        private static double Sum(LinkedListNode<double> node)
        {
            if (node.Previous == null)
            {
                return node.Value;
            }
            else
            {
                return node.Value + Sum(node.Previous);
            }
        } 
        static LinkedList<double> Solution(LinkedList<double> list)
        {
            LinkedList<double> list1 = new LinkedList<double>();

            foreach (double number in list)
            {
                list1.AddLast(Sum(list.Find(number)));
            }
            return list1;
        } 


        static void Main(string[] args)
        {
            LinkedList<double> list = new LinkedList<double>();

            list.AddLast(11.5);
            list.AddLast(23.3);
            list.AddLast(323.4);
            list.AddLast(-41.3);
            list.AddLast(53);
            list.AddLast(-16);
            list.AddLast(-56.7);

            var a = Solution(list);

            foreach (double num in a)
                Console.Write(num + " ");
        }
    }
}
