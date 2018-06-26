using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task8
    {
        static int n;
        static int[,] MyGraph;
        static bool[] used = new bool[n];

        static void Prepare()
        {
            Console.WriteLine("Введите N");
            Program.InputNumber(1, 100, out n);
            used = new bool[n];
        }
        static int[,] GraphGenerator(int size)
        {
            Random rnd = new Random();
            int[,] Graph = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j) { Graph[i, j] = 0; }
                    if (i < j)
                    {
                        int t = rnd.Next(2);
                        if (t == 0) { Graph[i, j] = 0; }
                        else { Graph[i, j] = 1; }
                    }
                    if (i > j) { Graph[i, j] = Graph[j, i]; }
                }
            }
            return Graph;
        }

        static void ShowGraph(int[,] grh)
        {
            string str = "  ";
            for (int d = 1; d <= grh.GetLength(1); d++)
            {

                str += d;
                str += " ";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(str);
            Console.ResetColor();

            for (int i = 0; i < grh.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(i + 1 + " ");
                Console.ResetColor();
                for (int j = 0; j < grh.GetLength(1); j++)
                {
                    if (grh[i, j] == 1) Console.Write(1 + " ");
                    else Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }

        static int Find()
        {

            for (int k = 1; k < n; ++k)
            {
                for (int i = 1; i < n; ++i)
                {
                    for (int j = 1; j < n; ++j)
                    {
                        if ((MyGraph[i, k] + MyGraph[k, j]) == 2)
                            MyGraph[i, j] = 1;
                    }
                }
            }

            int cnt = 0;
            for (int i = 1; i < n; ++i)
            {
                if (!used[i])
                {
                    ++cnt;
                    used[i] = true;
                    for (int j = 1; j < n; ++j)
                    {
                        if (MyGraph[i, j] == 1 && !used[j])
                            used[j] = true;
                    }
                }
            }
            return cnt;
        }
        public static void Launch()
        {
            Prepare();
            MyGraph = GraphGenerator(n);
            ShowGraph(MyGraph);
            Console.WriteLine("Компонент связанности: {0}", Find());
            Console.ReadLine();
        }
    }
}
