using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task4
    {
        public static void Launch()
        {
            double eps = -1;
            while (eps <= 0)
            {
                Console.WriteLine("Введите точность > 0");
                eps = Task3.InputDouble();
            } //ввод точности
            double sum = 0;
            int i = 1;
            double cur = 1;
            while (Math.Abs(cur) >= eps)
            {
                sum += cur;
                i++;
                cur = 1d / Math.Pow(i, 2);
            }//подсчет суммы ряда
            Console.WriteLine("Sum = "+ sum);
        }
    }
}
