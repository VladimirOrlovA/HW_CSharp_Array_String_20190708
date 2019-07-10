using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание: 
//Дана матрица размером NxM.Найти в ней подматрицу, имеющую ненулевые размеры,
//с максимальной суммой элементов.

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)

        {
            Random rnd = new Random();  // объявляем переменную для генерации псевдослучайных чисел
            int l = 4;
            int c = 4;

            int[,] arr = new int[l, c]; // объявляем двемерный массив

            // заполняем массив случайными числами
            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    arr[i, j] = rnd.Next(-100, 100);

            PrintArr(arr, l, c); // вызов функции вывода массива в консоль

            // ищем два максимальных значения в текущем массиве

            int max1 = -100, max2 = -100;
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    if (arr[i, j] > max1)
                    {
                        max1 = arr[i, j];
                        x1 = i;
                        y1 = j;
                    }


            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    if (x1 != i || y1 != j)
                        if (arr[i, j] > max2)
                        {
                            max2 = arr[i, j];
                            x2 = i;
                            y2 = j;
                        }

            Console.WriteLine("\n----------------------------------------------\n");
            Console.WriteLine(" max1 = " + max1 + " x1 = " + x1 + " y1 = " + y1);
            Console.WriteLine(" max2 = " + max2 + " x2 = " + x2 + " y2 = " + y2);

            // определяем размер подматрицы в пределах max1 и max2
            // определяем границы обхода подматрицы
            if (x1 > x2)
            {
                int tmpX = x1;
                x1 = x2;
                x2 = tmpX;
            }

            if (y1 > y2)
            {
                int tmpY = y1;
                y1 = y2;
                y2 = tmpY;
            }

            Console.WriteLine("\n----------------------------------------------\n");
            Console.WriteLine(" x1 = " + x1 + " y1 = " + y1);
            Console.WriteLine(" x2 = " + x2 + " y2 = " + y2);

            // вичесляем сумму элементов подматрицы по полученным координатам
            int sum = 0;
            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                    sum += arr[i, j];


            Console.WriteLine(" сумма элементов подматрицы = " + sum);

              
            Console.ReadKey(); 
            1
        }


        // функция вывода массива в консоль
        public static void PrintArr(int[,] arr, int l, int c)
        {
            Console.WriteLine("\n----------------------------------------------\n");

            for (int i = 0; i != l; i++)
            {
                for (int j = 0; j != c; j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }

    }
}
