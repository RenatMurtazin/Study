using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace HelloWorld
{
    class Program
    { 
        static void Print(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
        static void MergeSort(int[] array, ref int count)
        {
            if(array.Length < 2)
            {
                return; 
            }
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];
            for(int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            for (int i = mid; i < array.Length; i++)
            {
                right[i - mid] = array[i];
            }
            MergeSort(left, ref count);
            MergeSort(right,ref count);
            Merge(array, left, right, ref count);
        }
        static void Merge(int[] targetArray, int[] array1, int[] array2, ref int count)
        {
            int array1MinIndex = 0;
            int array2MinIndex = 0;
            int targetArrayMinIndex = 0;
            while ((array1MinIndex < array1.Length) && (array2MinIndex < array2.Length))
            {
                if (array1[array1MinIndex] <= array2[array2MinIndex])
                {
                    targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                    array1MinIndex++;
                    count++;
                }
                else
                {
                    targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                    array2MinIndex++;
                    count++;
                }
                targetArrayMinIndex++;
            }
            while(array1MinIndex < array1.Length)
            {
                targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                array1MinIndex++;
                targetArrayMinIndex++;
                count++;
            }
            while (array2MinIndex < array2.Length)
            {
                targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                array2MinIndex++;
                targetArrayMinIndex++;
                count++;
            }
        }

        static int[] ReadTest(string path)
        {
            string text = File.ReadAllText(path);

            string[] str = text.Split(',');

            int[] numbers = new int[str.Length];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = int.Parse(str[i]);
            }

            return numbers;
        }

        static void WriteToFile(string path, int[] numbers)
        {
            string str = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                str += numbers[i] + ",";
            }

            File.WriteAllText(path, str);
        }

        static void Main()
        {
            string path = @"D:\Input\Test";
            string output = @"D:\Output\Result";
            Console.WriteLine("Сортировка слиянием");
            int[] myArray;
            string timePlusArrayLength = "";
            for (int i = 0; i < 100; i++)
            {
                var time = new Stopwatch();
                myArray = ReadTest(path + i + ".txt");
                int count = 0;
                time.Start();
                MergeSort(myArray,ref count);
                time.Stop();
                timePlusArrayLength += time.ElapsedTicks + ";" + myArray.Length + ";" + count +  "\n";
                WriteToFile(output + i + ".txt", myArray);
            }
            File.WriteAllText(@"D:\Output\Table.csv", timePlusArrayLength);
            Console.WriteLine("Сложность алгоритма равна : n * log n");
           Console.ReadKey();
        }

    }
}
