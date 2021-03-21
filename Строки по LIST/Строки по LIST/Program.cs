using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Строки_по_LIST
{
    class MyList<T> { 
    private static int GetLargestString(List<string> list)
    {
        int maxLength = -1;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Length > maxLength)
                maxLength = list[i].Length;
        }
        return maxLength;
    }

    private static string ChangeString(string str, int maxLength)
    {
        string newString = "";
        for (int i = 0; i < maxLength; i++)
        {
            if (i < str.Length)
            {
                newString += str[i];
            }
            else
            {
                newString += "_";
            }
        }
        return newString;
    }

    public static List<string> all_eq(List<string> stringList)
    {
        int maxLength = GetLargestString(stringList);
        for (int i = 0; i < stringList.Count; i++)
        {
            stringList[i] = ChangeString(stringList[i], maxLength);
        }
        return new List<string>(stringList);
    }

}
class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
