using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task12
    {
        public static int n;//Кол-во элементов

        public static int[] clone;//Массив для клонирования (чтобы значений в изначальных массивах не изменялись)

        public static Random r = new Random();//Переменная для рандома

        public const int range = 10;//Количество возможных значений одного разряда
        public const int length = 2;//Максимальное количество разрядов в сортируемых величинах

        public static int transfer;//Кол-во пересылок
        public static int comparison;//Кол-во сравнений

        static void ReadN()//Ввод n (кол-во элементов)
        {
            bool ok;
            do
            {
                Console.Write("N=");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (ok && n <= 1) ok = false;
                if (!ok)
                {
                    Console.WriteLine("Введите целое число > 1");
                }
            } while (!ok);
        }

        //Создание массивов
        #region Create
        static int[] CreateDecrease(int[] m)
        {
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                    m[i] = m[i - 1] - r.Next(1, 5);
                else
                    m[i] = r.Next(60, 70);
            }

            return m;
        }//Создание убывающего массива

        static int[] CreateIncrease(int[] m)
        {
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                    m[i] = m[i - 1] + r.Next(1, 5);
                else
                    m[i] = r.Next(5);
            }

            return m;
        }//Создание возрастающего массива

        static int[] CreateUnordered(int[] m)
        {
            for (int i = 0; i < n; i++)
            {
                m[i] = r.Next(40);
            }

            return m;
        }//Создание неупорядоченного массива
        #endregion

        static void Show(int[] m)//Вывод массива на экран
        {
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", m[i]);
            Console.WriteLine();
        }

        //Сортировки
        #region Sort
        static void Sorting1(int[] a)//Блочная сортировка
        {
            List<int>[] aux = new List<int>[a.Length];

            for (int i = 0; i < aux.Length; ++i)
                aux[i] = new List<int>();

            int minValue = a[0];
            int maxValue = a[0];

            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i] < minValue)
                {
                    minValue = a[i];
                    comparison++;
                }
                else if (a[i] > maxValue)
                {
                    maxValue = a[i];
                    comparison++;
                }
            }

            double numRange = maxValue - minValue;

            for (int i = 0; i < a.Length; ++i)
            {
                int bcktIdx = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));
                aux[bcktIdx].Add(a[i]);
                transfer++;
            }

            for (int i = 0; i < aux.Length; ++i)
                aux[i].Sort();

            int idx = 0;

            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                {
                    a[idx++] = aux[i][j];
                    transfer++;
                }
            }
            Show(a);
        }



        public static void Sorting2(int[] arr)//Пирамидальная сортировка
        {
            //шаг 1: постройка пирамиды
            for (int i = n / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = AddPyramid(arr, i, n);
                if (prev_i != i)
                {
                    ++i;
                    comparison++;
                }
            }

            //шаг 2: сортировка
            int buf;
            for (int k = n - 1; k > 0; --k)
            {
                buf = arr[0];
                transfer++;
                arr[0] = arr[k];
                transfer++;
                arr[k] = buf;
                transfer++;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = AddPyramid(arr, i, k);
                }
            }

            Show(arr);
        }
        static int AddPyramid(int[] arr, int i, int N)//Построение пирмаиды для сортировки
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2])
                {
                    imax = 2 * i + 2;
                    comparison++;
                }
                else
                {
                    imax = 2 * i + 1;
                    comparison++;
                }

                comparison++;
            }
            else
            {
                imax = 2 * i + 1;
                comparison++;
            }

            if (imax >= N)
            {
                comparison++;
                return i;
            }
            if (arr[i] < arr[imax])
            {
                comparison++;
                buf = arr[i];
                transfer++;
                arr[i] = arr[imax];
                transfer++;
                arr[imax] = buf;
                transfer++;
                if (imax < N / 2)
                {
                    i = imax;
                    comparison++;
                }
            }
            return i;
        }
        #endregion 

        public static void Launch()
        {
            ReadN();//Ввод n

            int[] decrease = new int[n];//Убывание
            int[] increase = new int[n];//Возрастание
            int[] unordered = new int[n];//Неупорядоченный

            Console.WriteLine("Первоначальные массивы: ");

            Console.Write("Возрастание: ");
            increase = CreateIncrease(increase);
            Show(increase);

            Console.Write("Убывание: ");
            decrease = CreateDecrease(decrease);
            Show(decrease);

            Console.Write("Неупорядоченный: ");
            unordered = CreateUnordered(unordered);
            Show(unordered);


            Console.WriteLine();

            Console.WriteLine("Блочная сортировка:");

            transfer = 0;
            comparison = 0;
            Console.Write("Возрастание: ");
            clone = (int[])increase.Clone();
            Sorting1(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            transfer = 0;
            comparison = 0;
            Console.Write("Убывание: ");
            clone = (int[])decrease.Clone();
            Sorting1(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            transfer = 0;
            comparison = 0;
            Console.Write("Неупорядоченный: ");
            clone = (int[])unordered.Clone();
            Sorting1(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            Console.WriteLine();

            Console.WriteLine("Пирамидальная сортировка:");

            transfer = 0;
            comparison = 0;
            Console.Write("Возрастание: ");
            clone = (int[])increase.Clone();
            Sorting2(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            transfer = 0;
            comparison = 0;
            Console.Write("Убывание: ");
            clone = (int[])decrease.Clone();
            Sorting2(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            transfer = 0;
            comparison = 0;
            Console.Write("Неупорядоченный: ");
            clone = (int[])unordered.Clone();
            Sorting2(clone);
            Console.WriteLine("Пересылки: {0}", transfer);
            Console.WriteLine("Сравнений: {0} ", comparison);

            Console.ReadLine();
        }
    }
}
