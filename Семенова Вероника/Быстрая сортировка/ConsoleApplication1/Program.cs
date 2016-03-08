using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void QuickSort(int[] array, int left, int right)
        {
            if (right > 0 && left>=0)
            {
                int Buf;
                int mid = array[left + (right - left) / 2];
                int i = left;
                int j = right;
                while (i <= j)
                {
                    while (array[i] < mid) i++;
                    while (array[j] > mid) j--;
                    if (i <= j)
                    {
                        Buf = array[i];
                        array[i] = array[j];
                        array[j] = Buf;
                        i++;
                        j--;
                    }
                }
                if (i < right)
                    QuickSort(array, i, right);

                if (left < j)
                    QuickSort(array, left, j);
            }
        }

        static void Main(string[] args)
        {
            TestArrayOf3Elements();
            TestArrayOf100TheSameNumbers();
            TestArrayOf100Numbers();
            TestEmptyArray();
            Console.ReadLine();
            
        }

        public static void TestArrayOf3Elements()
        {
            int[] mass = new int[] { 1, 4, 2};
            QuickSort(mass, 0, mass.Length-1);
            if (mass[0] == 1 && mass[1] == 2 && mass[2]==4)
                Console.WriteLine("1. Сортировка массива из 3 элементов выполнена успешно.");
            else
                Console.WriteLine("! 1. Сортировка массива из 3 элементов работает некорректно.");
        }

        public static void TestArrayOf100TheSameNumbers()
        {
            int[] mass = new int[100];
            for (int i=0; i<100; i++)
            {
                mass[i] = 15;
            }
            QuickSort(mass, 0, mass.Length-1);
            int Counter=0;
            for (int i=0; i<100; i++)
            {
                if (mass[i] == 15)
                    Counter++;
            }
            if (Counter == 100)
                Console.WriteLine("2. Сортировка массива из 100 одинаковых элементов выполнена успешно.");
            else
                Console.WriteLine("! 2. Сортировка массива из 100 одинаковых элементов выполнена некорректно.");
        }

        public static void TestArrayOf100Numbers()
        {
            int[] mass = new int[100];
            int[] Test = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next();
            }
            for (int i = 0; i < Test.Length; i++)
            {
                Test[i] = rnd.Next(0,100);
            }
            QuickSort(mass, 0, mass.Length - 1);
            int Counter=0;
            for (int i=0; i<10; i++)
            {
                if (mass[Test[i]] < mass[Test[i]+1])
                    Counter++;
            }
            if (Counter == 10)
                Console.WriteLine("3. Сортировка массива из 100 элементов прошла успешно.");
            else
                Console.WriteLine("! 3. Сортировка массива из 100 элементов прошла некорректно.");
        }

        public static void TestEmptyArray()
        {
            int[] mass = new int[0];
            QuickSort(mass, 0, mass.Length - 1);
            if (mass.Length == 0)
                Console.WriteLine("4. Сортировка пустого массива прошла успешно.");
            else
                Console.WriteLine("! 4. Сортировка пустого массива прошла некорректно.");
        }
    }
}
