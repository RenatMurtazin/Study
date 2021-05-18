using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ControlWork2Task1
{
    class Program
    {
        static void Merge(List<List<double>> listOfLists,int n)
        {
            List<double> list1 = listOfLists[0];
            for (int i = 1; i < listOfLists.Count; i++)
            {
                list1 = list1.Union(listOfLists[i]).ToList();
            }
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(list1[j]);
            }
        }
        static void Main(string[] args)
        {
            List<List<double>> listOfLists = new List<List<double>>();
            List<double> list1 = new List<double>() { 1, 2, 3, 4 };
            List<double> list2 = new List<double>() { 4, 5, 6, 7 };
            listOfLists.Add(list1);
            listOfLists.Add(list2);
            Merge(listOfLists,7);
            Console.ReadKey();
        }
    }
}
