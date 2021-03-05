using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Анонимные_методы
{
    class Program
    {

        delegate double GetAvarege(RandomNumbers[] numbers);

        delegate int RandomNumbers();

        static int GetRandomNumber()
        {
            return new Random().Next();
        }

        static GetAvarege avarage = delegate (RandomNumbers[] numbers)
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i]();
            }
            return (double)sum / numbers.Length;
        };

        static void Main(string[] args)
        {
            Console.Write("Введите число элементов массива");
            int count = int.Parse(Console.ReadLine());

            RandomNumbers[] numbers = new RandomNumbers[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = GetRandomNumber;
            }

            Console.WriteLine($"Среднее арефметическое - {avarage(numbers)}");
            Console.ReadKey();
        }
    }
}