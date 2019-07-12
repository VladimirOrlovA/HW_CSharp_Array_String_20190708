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
            Random rnd = new Random();  // объявляем переменную/объект для генерации псевдослучайных чисел
            int l = 4;
            int c = 4;

            int[,] arr = new int[l, c]; // объявляем двемерный массив

            // заполняем массив случайными числами
            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    arr[i, j] = rnd.Next(-100, 100);

            Console.WriteLine("\n------------- исходная матрица ---------------\n");

            PrintArr(arr, l, c); // вызов функции вывода массива в консоль

            int max1 = -100, max2 = -100, count = 0, maxSumArr = 0;
            int x1 = 0, y1 = 0, x2 = -1, y2 = -1;

            // ищем подматрицу, имеющую ненулевые размеры, с максимальной суммой элементов.
            while (count < 20)
            {



                if (count > 0)
                {
                    max1 = max2;
                    max2 = -100;
                }

                for (int i = 0; i != l; i++)
                    for (int j = 0; j != c; j++)
                        if (arr[i, j] > max1 && count == 0)
                        {
                            max1 = arr[i, j];
                            x1 = i;
                            y1 = j;
                        }
                        else if (arr[i, j] == max1 && count != 0)
                        {
                            x1 = i;
                            y1 = j;
                        }

                for (int i = 0; i != l; i++)
                    for (int j = 0; j != c; j++)
                        if (arr[i, j] > max2 && arr[i, j] < max1)
                        {
                            max2 = arr[i, j];
                            x2 = i;
                            y2 = j;
                        }

                //Console.WriteLine("\n----------- координаты максимумов ------------\n");
                //Console.WriteLine(" max1 = " + max1 + " x1 = " + x1 + " y1 = " + y1);
                //Console.WriteLine(" max2 = " + max2 + " x2 = " + x2 + " y2 = " + y2);

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

                Console.WriteLine("\n----------- координаты подматрицы ------------\n");
                Console.WriteLine(" x1 = " + x1 + " y1 = " + y1);
                Console.WriteLine(" x2 = " + x2 + " y2 = " + y2);

                // вичесляем сумму элементов подматрицы по полученным координатам
                int sum = 0;

                if (x1!=x2 && y1!=y2) // смотрим/считаем подматрицу имеющую ненулевые размеры
                {
                    Console.WriteLine("\n--------------- подматрица № {0} -------------------\n", count + 1);

                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            Console.Write(arr[i, j] + "\t");
                            sum += arr[i, j];
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nCумма элементов подматрицы = " + sum);
                    Console.WriteLine("\n----------------------------------------------\n");
                    //count++;
                }
                count++;
            }
            Console.ReadKey();
        }


        // функция вывода массива в консоль
        public static void PrintArr(int[,] arr, int l, int c)
        {
            for (int i = 0; i != l; i++)
            {
                for (int j = 0; j != c; j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }

    }
}
