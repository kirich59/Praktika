using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Program
    {
        private static void InputNumber(int left, int right, out int number)
        {
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok) Console.WriteLine("Неверный ввод, попробуйте снова");
                else
                {
                    if (number < left) { Console.WriteLine("Слишком маленькое число"); ok = false; };
                    if (number > right) { Console.WriteLine("Слишком большое число"); ok = false; };
                }
            }
            while (!ok);
        }
        private static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Задание 1.\n"
                    + "2. Задание 3.\n"
                    + "3. Задание 4.\n"
                    + "4. Задание 5.\n"
                    + "5. Задание 6.\n"
                    + "6. Задание 8.\n"
                    + "7. Задание 9.\n"
                    + "8. Задание 11.\n"
                    + "9. Задание 12.\n"
                    + "10. Выход.\n");
                int sw;
                InputNumber(1, 10, out sw);
                switch (sw)
                {
                    case 1:
                        try
                        {
                            Task1.Launch();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Создайте файл INPUT.TXT в директории проекта");
                        }
                        break;
                    case 2:
                        Task3.Launch();
                        break;
                    case 3:
                        Task4.Launch();
                        break;
                    case 4:
                        Task5.Launch();
                        break;
                    case 5:
                        Task6.Launch();
                        break;
                    case 6:
                        Task8.Launch();
                        break;
                    case 7:
                        Task9.Launch();
                        break;
                    case 8:
                        Task11.Launch();
                        break;
                    case 9:
                        Task12.Launch();
                        break;
                    case 10:
                        exit = true;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
