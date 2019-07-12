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
            int l = 5;
            int c = 5;

            int max1 = -100,        // для превого максимума
                max2 = max1 - 1,    // чтобы обеспечить неравенство max1 и max2 в цикле while
                min = 100,          // чтобы найти последний минимальный max2 и остановить цикл while 
                count = 0,          // для удобной отладки в консоли
                sum = 0,            // сумма элементов подматрицы
                maxSumArr = 0,      // подматрица с максимальной суммой 
                matrixNumber = 0;

            // координаты для подматриц в основной матрице 
            //x2 = -1, y2 = -1 чтобы нормально работала проверка на ненулевую матрицу 116 строка
            int x1 = 0, y1 = 0, x2 = -1, y2 = -1;
            int mx1 = 0, my1 = 0, mx2 = 0, my2 = 0; // координаты для подматрицы имеющей макс сумму элементов

            int[,] arr = new int[l, c]; // объявляем двумерный массив

            // заполняем массив случайными числами
            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    arr[i, j] = rnd.Next(max1, min);

            Console.WriteLine("\n----------------- Исходная матрица -------------------\n");

            PrintArr(arr, l, c); // вызов функции вывода массива в консоль

            // находим минимальный элемент матрицы для остановки перебора подматриц
            for (int i = 0; i != l; i++)
                for (int j = 0; j != c; j++)
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
            // вывод в консоль для отладки
            //Console.WriteLine("мин эл матрицы = " + min);

            // ищем подматрицу, имеющую ненулевые размеры, с максимальной суммой элементов.
            while (max1 != max2)
            {
                if (count != 0)
                {
                    max1 = max2;
                    max2 = min;
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
                // вывод в консоль для отладки
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

                // вывод в консоль для отладки
                //Console.WriteLine("\n----------- координаты подматрицы ------------\n");
                //Console.WriteLine(" x1 = " + x1 + " y1 = " + y1);
                //Console.WriteLine(" x2 = " + x2 + " y2 = " + y2);

                // вичесляем сумму элементов подматрицы по полученным координатам
                sum = 0;

                if (!(x1 == x2 && y1 == y2)) // смотрим/считаем подматрицу имеющую ненулевые размеры
                //    //Console.WriteLine("нулевая");
                //else
                {
                    // вывод в консоль для отладки
                    //Console.WriteLine("\n--------------- подматрица № {0} -------------------\n", count + 1);

                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            //Console.Write(arr[i, j] + "\t"); 
                            sum += arr[i, j];
                        }
                        //Console.WriteLine();
                    }

                    // вывод в консоль для отладки
                    //Console.WriteLine("\nCумма элементов подматрицы = " + sum);
                    //Console.WriteLine("\n----------------------------------------------\n");

                    if (maxSumArr < sum)
                    {
                        maxSumArr = sum;
                        mx1 = x1;
                        my1 = y1;
                        mx2 = x2;
                        my2 = y2;
                        matrixNumber = count;
                    }

                }
                count++;
            }
            // вывод в консоль для отладки
            //Console.WriteLine("Макс сумма подматрицы = " + maxSumArr);

            // вывод в консоль максимальной подматрицы 
            Console.WriteLine("\n\n\n---- Подматрица с максимальной суммой элементов ------\n");
            Console.WriteLine("   Номер подматрицы = " + (matrixNumber + 1) + ", сумма элементов = " + maxSumArr);

            Console.WriteLine("\n--------------- координаты подматрицы ----------------\n");
            Console.WriteLine(" x1 = " + mx1 + "\t x2 = " + mx2);
            Console.WriteLine(" y1 = " + my1 + "\t y2 = " + my2);
            Console.WriteLine("\n");

            for (int i = mx1; i <= mx2; i++)
            {
                for (int j = my1; j <= my2; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n------------------------------------------------------\n");
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
