using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task7
    {
        public static void Launch()
        {
            string func = string.Empty;
            string answer = string.Empty;

            do
            {
                Console.Write("Введите булеву функцию: ");
                func = Console.ReadLine();
            } while (!CheckFunction(func));

            if (IsTZero(func)) answer += "T0 ";
            if (IsTOne(func)) answer += "T1 ";
            if (IsMonatic(func)) answer += "M ";
            if (IsSelfDual(func)) answer += "S ";
            if (IsLinear(func)) answer += "L ";

            Console.WriteLine(answer);
        }

        static bool IsPowerOfTwo(int number)
        {
            if (number == 2) return true;
            if (number % 2 == 0) return IsPowerOfTwo(number / 2);
            return false;
        }

        static bool CheckFunction(string func)
        {
            //Проверка всех символов
            foreach (char i in func)
                if (i != '0' && i != '1')
                    return false;

            //Проверка на степень двойки
            if (!IsPowerOfTwo(func.Length)) return false;
            return true;
        }
        
        static bool IsTZero(string func)
        {
            return func[0] == '0';
        }

        static bool IsTOne(string func)
        {
            return func.Last() == '1';
        }

        static bool IsMonatic(string func)
        {
            bool existOne = false;

            foreach (char i in func)
                if (i == '1') existOne = true;
                else if (existOne) return false;

            return true;
        }

        static bool IsSelfDual(string func)
        {
            for (int i = 0, j = func.Length - 1; i < j; i++, j--)
                if (func[i] == func[j]) return false;

            return true;
        }

        static bool IsLinear(string func)
        {
            bool[] vector = GetPascalTriangle(func);
            Pereberator pereberator = new Pereberator(func.Length - 1);

            int j = -1;
            foreach (string i in pereberator)
                if (i.CountOfOne() > 1 & vector[++j] == true) return false;

            return true;
        }
    
        static bool[] GetPascalTriangle(string func)
        {
            bool[,] pascalT = new bool[func.Length, func.Length];
            bool[] vector = new bool[func.Length];

            for (int i = 0, shift = 1; i < func.Length - 1; i++, shift++)
                if (i == 0)
                    for (int j = 0; j < func.Length; j++)
                    {
                        pascalT[i, j] = func[j] == '1';
                        if (j == 0) vector[0] = pascalT[i, j];
                    }
                else
                    for (int j = func.Length - shift; j > -1; j--)
                    {
                        pascalT[i, j] = pascalT[i - 1, j + 1] != pascalT[i - 1, j];
                        if (j == 0) vector[i] = pascalT[i, j]; 
                    }

            return vector;
        }
    }

    public class Pereberator : IEnumerable
    {
        protected int _maxNumber;
        protected string _maxNumberByteMask;

        public Pereberator(int number)
        {
            MaxNumber = number;
        }

        private int MaxNumber
        {
            get => _maxNumber;

            set
            {
                _maxNumber = value;
                _maxNumberByteMask = BytePresenter(value);
            }
        }
         
        private string this[int i] => LeadToPattern(BytePresenter(i));

        private int PermutationsCount => (int)Math.Pow(2, MaxNumberByteMask.Length);

        private string MaxNumberByteMask => _maxNumberByteMask;

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < PermutationsCount; i++)
                yield return LeadToPattern(this[i]);
        }

        private static string BytePresenter(int number)
        {
            var bytePeresenterString = string.Empty;

            do
            {
                bytePeresenterString = number % 2 + bytePeresenterString;
                number /= 2;
            } while (number > 0);

            return bytePeresenterString;
        }

        private string LeadToPattern(string byteNumber)
        {
            while (byteNumber.Length < MaxNumberByteMask.Length)
                byteNumber = "0" + byteNumber;

            return byteNumber;
        }
    }

    public static class StringExtansion
    {
        public static int CountOfOne(this string current)
        {
            int count = 0;
            foreach (char i in current)
                if (i == '1') ++count;

            return count;
        }
    }
}
