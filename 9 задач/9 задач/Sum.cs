using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_задач
{
    class Sum
    {
        public LinkedList<int> list1;


        public Sum(LinkedList<int> list) { this.list1 = list; }

        private int GetValuesToZero(LinkedListNode<int> node)
        {
            if (node.Previous == null)
            {
                return node.Value;
            }
            else
                return node.Value + GetValuesToZero(node.Previous);
        }

        public void GetSum()
        {
            LinkedList<int> list2 = new LinkedList<int>();
            foreach (int number in list1)
            {
                list2.AddLast(GetValuesToZero(list1.Find(number)));
            }
            list1 = list2;
        }
    }
}
