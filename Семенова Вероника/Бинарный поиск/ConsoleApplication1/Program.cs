using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            int left = 0, right = array.Length-1, middle;
            while (left<=right)
            {
                middle = left + (right - left) / 2;
                if(value<array[middle])
                    right = middle - 1;
                else
                {
                    if (value>array[middle])
                        left = middle + 1;
                    else
                        return (middle);
                }
            }
            return (-1);
        }

        static void Main(string[] args)
        {
            TestOneElementFrom5();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestTheSameNumbers();
            TestEmptyArray();
            TestArrayOf100001Elements();
            

            Console.ReadKey();
        }

        private static void TestNegativeNumbers()
        {
            //Тестирование поиска в отрицательных числах
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! 2. Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("2. Поиск среди отрицательных чисел работает корректно");
        }

        private static void TestNonExistentElement()
        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! 3. Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("3. Поиск отсутствующего элемента вернул корректный результат");
        }

        private static void TestOneElementFrom5()
        {
            // тестирование поиска среди одного элемента из 5 элементов массива
            int[] Numbers = new[] { 1, 2, 3, 4, 5 };
            if (BinarySearch(Numbers, 2) == 1)
                Console.WriteLine("1. Поиск одного элемента из 5 прошел успешно");
            else
                Console.WriteLine("! 1. Поиск одного элемента из 5 дал некорректный результат");
        }

        private static void TestTheSameNumbers()
        {
            // тестирование поиска одинаковых элементов массива
            int[] Numbers = new[] { 1, 2, 3, 3, 4, 4, 5 };
            int Test = 0;
            for (int i=0; i<Numbers.Length; i++)
            {
                if (BinarySearch(Numbers, Numbers[i])!=i)
                    Test++;
            }
            if (Test==2)
                Console.WriteLine("4. Поиск одинаковых элементов прошел успешно");
            else
                Console.WriteLine("! 4. Поиск одинаковых элементов дал некорректный результат");
        }

        private static void TestEmptyArray()
        {
            //тестирование поиска в пустом массиве
            int[] EmptyMass = new int[0];
            if (BinarySearch(EmptyMass, 0) != (-1))
                Console.WriteLine("! 5. Поиск в пустом массиве прошел некорректно");
            else
                Console.WriteLine("5. Поиск в пустом массиве прошел корректно");
        }

        private static void TestArrayOf100001Elements()
        {
            // тестирование массива из 100001 элемента
            int[] array = new int[100001];
            Random rand = new Random();
            for (int i=0; i<100001; i++)
            {
                array[i] = rand.Next(-100000,100000);
            }
            Array.Sort(array);
            int Test = BinarySearch(array, 12);
            if (Test==-1 || array[Test] == 12)
                Console.WriteLine("6. Поиск числа в массиве из 100001 элемента выполнен успешно");
            else
                Console.WriteLine("! 6. Поиск числа в массиве из 100001 элемента выполнен некорректно");
        }
     
    }
}

