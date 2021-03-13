using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Таблица_list
{
    class SortData
    {

        const int _OrderDateColumn = 2;
        const int _OrderPriorityColumn = 3;
        const int _ShipDateColumn = 20;
        const int _ClientName = 11;
        const int _ProductName = 17;
        Dictionary<string, int> priority = new Dictionary<string, int>();

        public string Text { get; set; }


        public List<string[]> Data = new List<string[]>();

        public SortData(string path)
        {
            Text = File.ReadAllText(path);

            string[] rows = Text.Split('\n');

            for (int i = 0; i < rows.Length; i++)
            {
                Data.Add(rows[i].Split(';'));
            }

            priority.Add("Not Specified", 0);
            priority.Add("x", 1);
            priority.Add("Low", 2);
            priority.Add("Medium", 3);
            priority.Add("High", 4);
            priority.Add("Critical", 5);
        }

        private int CompareToPriority(string x, string y)
        {
            if (priority[x] > priority[y])
                return 1;
            else if (priority[x] < priority[y])
                return -1;
            else return 0;
        }

        private int CompareToDate(string x, string y)
        {
            bool xMoreTnanY = false;
            string[] xDate = x.Split('.');
            string[] yDate = y.Split('.');
            for (int i = 2; i >= 0; i--)
            {
                if (int.Parse(xDate[i]) > int.Parse(yDate[i]))
                {
                    return 1;
                }
                else if (int.Parse(xDate[i]) == int.Parse(yDate[i]))
                {
                    if (i == 0)
                        return 0;
                    continue;
                }
                else return -1;
            }

            return -1;
        }


        public void OrderDateSort()
        {
            for (int i = 1; i <= 150; i++)
            {
                for (int j = 1; j < 150; j++)
                {
                    if (CompareToDate(Data[j][_OrderDateColumn], Data[j + 1][_OrderDateColumn]) != 1)
                    {
                        string[] temp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = temp;
                    }
                }
            }
        }

        public void Sort()
        {
            OrderDateSort();

            for (int i = 1; i <= 150; i++)
            {
                for (int j = 1; j < 150; j++)
                {
                    if ((CompareToDate(Data[j][_OrderDateColumn], Data[j + 1][_OrderDateColumn]) == 0
                       && CompareToPriority(Data[j][_OrderPriorityColumn], Data[j + 1][_OrderPriorityColumn]) == -1)
                       || (CompareToDate(Data[j][_OrderDateColumn], Data[j + 1][_OrderDateColumn]) == 0
                       && CompareToPriority(Data[j][_OrderPriorityColumn], Data[j + 1][_OrderPriorityColumn]) == 0)
                       && CompareToDate(Data[j][_ShipDateColumn], Data[j + 1][_ShipDateColumn]) == -1)
                    {
                        string[] temp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = temp;
                    }
                }
            }
        }

        public void WriteToFile()
        {
            string path = @"D:\Table.csv";
            FileStream newFile = new FileStream(path, FileMode.Create);

            string text = "";
            for (int i = 0; i <= 150; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    if (j == 20)
                    {
                        text += Data[i][j] + "\n";
                        break;
                    }
                    text += Data[i][j] + ";";
                }
            }
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            newFile.Write(array, 0, array.Length);
            Console.WriteLine("Success!");
        }
        public void WriteOrderInformation(int strNumber)
        {
            Console.WriteLine($"Имя клиента {Data[strNumber][_ClientName]}");
            Console.WriteLine($"Дата заказа {Data[strNumber][_OrderDateColumn]}");
            Console.WriteLine($"Название продукта {Data[strNumber][_ProductName]}");
        }
        public void RemoveOrder(int strNumber)
        {
            Console.WriteLine("Заказ удален");
            Data.RemoveAt(strNumber);
        }

    }
    class Program 
    {
    static void Main(string[] args)
    {
            Console.WriteLine("Введите номер строки");
            int strNumber = int.Parse(Console.ReadLine());
        string path = @"D:\Sample - Superstore Sales (Excel).txt";

        SortData myData = new SortData(path);

        myData.Sort();

        myData.WriteToFile();
            myData.WriteOrderInformation(strNumber);
            myData.RemoveOrder(strNumber);
            myData.WriteOrderInformation(strNumber);
            Console.ReadKey();
    }
  }
}
