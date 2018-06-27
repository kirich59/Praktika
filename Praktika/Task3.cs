using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task3
    {
        //ввод вещественного числа с проверкой
        public static double InputDouble()
        {
            double x;
            while (!Double.TryParse(Console.ReadLine(), out x)) Console.WriteLine("Повторите попытку");
            return x;
        }

        //запуск задания
        public static void Launch()
        {
            Console.WriteLine("Введите координату x");
            double x = InputDouble();
            Console.WriteLine("Введите координату у");
            double y = InputDouble();
            bool relatesTo = false;
            if (y >= Math.Pow(x,2) && ((x <= 0 && y <= Math.Pow(Math.E, x)) || (x >= 0 && y <= Math.Pow(Math.E, -x)))) relatesTo = true;
            if (x == 0 && y == 0) relatesTo = true;
            if (relatesTo) Console.WriteLine("u = {0}", (x + y));
            else Console.WriteLine("u = {0}", (x - y));
        }
    }
}
