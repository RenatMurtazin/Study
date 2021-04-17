using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_задач
{
    class Equals
    {
        LinkedList<int> list1 = new LinkedList<int>();
        LinkedList<int> list2 = new LinkedList<int>();

        public Equals(LinkedList<int> list1, LinkedList<int> list2)
        {
            if (list1.Count <= list2.Count)
            {
                this.list1 = list1;
                this.list2 = list2;
            }
            else
            {
                this.list1 = list2;
                this.list2 = list1;
            }
        }

        public bool EqualsCheck()
        {
            LinkedList<int> temp = new LinkedList<int>();
            foreach (int num in list2)
                temp.AddLast(num);

            bool equals = true;

            foreach (int i in list1)
            {
                foreach (int j in temp)
                {
                    if (i == j)
                    {
                        temp.Remove(temp.Find(j));
                        break;
                    }
                    else
                    {
                        equals = false;
                    }
                    if (!equals)
                        break;
                }
                if (!equals)
                    break;
            }

            return equals;
        }
    }
}
