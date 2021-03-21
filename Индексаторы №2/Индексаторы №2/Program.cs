using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Индексаторы__2
{
    class Program
    {
        class Arr
        {
            public int columns { get; private set; }

            public int rows { get; private set; }

            private int[,] array { get; set; }


            public int ArraySize { get { return columns * rows; } }


            public Arr() { }

            public Arr(int rows, int columns)
            {
                this.rows = rows;
                this.columns = columns;
                array = new int[rows, columns];
            }

            public int this[int rows,int columns]
            {
                get { return array[rows, columns]; }
                set { array[rows, columns] = value; }
            }

            public int this[int column]
            {
                set
                {
                    for (int i = 0; i < rows; i++)
                    {
                        value = int.Parse(Console.ReadLine());
                        array[i, column] = value;
                    }
                }

                get
                {
                    string str = "";
                    for (int i = 0; i < rows; i++)
                    {
                        str += array[i, column] + " ";
                    }
                    Console.WriteLine(str);
                    return 0;
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
