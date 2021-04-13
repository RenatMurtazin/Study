using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1
{
    struct SetofStack
    {
        public int Max;
        public List<Stack<int>> stack;
        public int Count;

        public void Push(int item)
        {
            if (Count % Max == 0)
            {
                stack.Add(new Stack<int>());
                stack[stack.Count - 1].Push(item);
                Count++;
            }
            else
            {
                stack[stack.Count - 1].Push(item);
                Count++;
            }
        }
        public SetofStack(int max)
        {
            this.Max = max;
            stack = new List<Stack<int>>();
            Count = 0;
        }

        public int Pop()
        {
            int pop = stack[stack.Count - 1].Pop();
            Count--;
            return pop;
        }
    }
}
