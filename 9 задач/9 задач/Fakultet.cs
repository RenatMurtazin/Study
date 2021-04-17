using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_задач
{
    class Fakultet
    {
        public LinkedList<LinkedList<string>> facult = new LinkedList<LinkedList<string>>();
        public LinkedList<string> Group(string[] names)
        {
            LinkedList<string> group = new LinkedList<string>();
            for (int i = 0; i < names.Length; i++)
            {
                group.AddLast(names[i]);
            }
            return group;
        }
        public LinkedList<LinkedList<string>> Facult(string[] allNames)
        {
            for (int i = 0; i < allNames.Length; i++)
            {
                facult.AddLast(Group(allNames[i].Split(' ')));
            }
            return facult;
        }
    }
}
