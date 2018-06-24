using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    public class MyList
    {
        MyList next;
        int value;
        public static int Count = 0;

        public int this[int index]
        {
            get
            {
                MyList current = this;

                for (int i = 0; i <= index && current != null; i++)
                    if (i == index)
                        return current.value;
                    else
                        current = current.next;

                return -1;
            }
        }

        protected MyList(int num)
        {
            value = num;
            next = null;
            ++Count;
        }

        public static MyList Create(int N)
        {
            MyList begining = new MyList(N);
            MyList current = begining;

            for (int i = N-1; i >= 0; i--)
            {
                current.next = new MyList(i);
                current = current.next;
            }

            return begining;
        }

        public static void Clear()
        {
            Count = 0;
        }
    }

    class Task9
    {
        public static void Launch()
        {
            int n = 0;
            while (n <= 0)
            {
                Console.WriteLine("Введите число N");
                n = Task5.InputInt();
                if (n <= 0) Console.WriteLine("Введенное число должно быть > 0");
            }
            MyList myList = MyList.Create(n);
            string answer = null;
            for (int i = 0; i < MyList.Count; i++)
                answer += myList[i] + " ";
            MyList.Clear();
            Console.WriteLine(answer);
        }
    }
}
