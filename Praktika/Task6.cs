using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task6
    {
        static double last;
        private static void Recursion(double a1,double a2,double a3,double M)
        {
            double ak = a3 * a2 + a1;
            Console.WriteLine(ak + " ");
            if (ak < M) Recursion(a2, a3, ak, M);
            else last = ak;
        }
        public static void Launch()
        {
            double a1, a2, a3, M;
            Console.WriteLine("Введите а1");
            a1=Task3.InputDouble();
            Console.WriteLine("Введите а2");
            a2 = Task3.InputDouble();
            Console.WriteLine("Введите а3");
            a3 = Task3.InputDouble();
            Console.WriteLine("Введите М");
            M = Task3.InputDouble();
            if (a3 * a2 + a1 >= M)
                if (a3 * a2 + a1 != M) Console.WriteLine((a3 * a2 + a1) + "\n" + "aN!=M");
                else Console.WriteLine(M + "\n" + "aN==M");
            else
            {
                if ((a1 == 0 && a2 == 0)||(a1==0&&a3==0) || (a2 == 0 && a3 == 0))
                {
                    Console.WriteLine("Невозможно построить последовательность с данными числами");
                    Launch();
                }
                else
                {
                    Recursion(a1, a2, a3, M);
                    if (last == M) Console.WriteLine("aN==M");
                    else Console.WriteLine("aN!=M");
                }
            }
        }
    }
}
