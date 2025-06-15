using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosiv
{
    internal class Program
    {
        static void Main()
        {
            const int arrayLength = 20;
            Random random = new Random();



            int[] array1 = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)

            {
                array1[i] = random.Next(101);
            }


            int[] array2 = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)

            {
                array2[i] = random.Next(101);
            }


            Console.WriteLine("Первый массив:");
            foreach (var item in array1)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\n\nВторой массив:");
            foreach (var item in array2)
            {
                Console.Write($"{item} ");
            }
        }
    }
}