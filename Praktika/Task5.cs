using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task5
    {
        public static int InputInt()
        {
            int x;
            while (!Int32.TryParse(Console.ReadLine(), out x)) Console.WriteLine("Повторите попытку");
            return x;
        }
        private static int[,] MatrixInput(int size)
        {
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Введите строку " + (i + 1));
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = InputInt();
                }
            }
            return matrix;
        }
        static void Vector(int[,] matrix)
        {
            bool decreasing;
            int tmp;
            int size = matrix.GetLength(0);
            string res = null;
            for (int i = 0; i < size; i++)
            {
                tmp = matrix[i, 0];
                decreasing = tmp < matrix[i, size - 1];
                for (int j = 0; j < size - 1; j++)
                {
                    if (decreasing && matrix[i, j] >= matrix[i, j + 1])
                    {
                        res += '0';
                        break;
                    }
                    else if (!decreasing && matrix[i, j] <= matrix[i, j + 1])
                    {
                        res += '0';
                        break;
                    }
                    else if (j == size - 2)
                        res += '1';
                }
            }
            Console.WriteLine(res);
        }
        public static void Launch()
        {
            Console.WriteLine("Введите размер матрицы");
            int size = 0;
            while (size < 2)
            {
                size = InputInt();
                if (size < 2) Console.WriteLine("Размер должен быть >= 2");
            }
            Vector(MatrixInput(size));
        }
    }
}
