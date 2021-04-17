using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _9_задач
{
    class Lines
    {
        public LinkedList<int> count = new LinkedList<int>();
        private string[] lines;

        public Lines(string path)
        {
            lines = File.ReadAllText(path).Split('\n');
        }

        public LinkedList<int> CharsInLines()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                count.AddLast(lines[0].Length);
            }
            return count;
        }
    }
}
