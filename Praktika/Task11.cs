using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    class Task11
    {
        static string SignalInput()
        {
            bool ok = false;
            string signal = null;
            while (!ok)
            {
                Console.WriteLine("Введите сигнал");
                signal = Console.ReadLine();
                foreach (char c in signal)
                {
                    if (c != '0' && c != '1')
                    {
                        Console.WriteLine("Сигнал должен состоять из 0 и 1");
                        signal = null;
                        break;
                    }
                }
                if (signal != null&&signal!="")
                {
                    if (signal.Length % 3 == 0) ok = true;
                    else Console.WriteLine("Длина последовательности должна быть кратна 3");
                }
            }
            return signal;
        }
        public static void Launch()
        {
            string signal = SignalInput();
            string outSignal = null;
            for (int i = 0; i + 2 < signal.Length; i += 3)
            {
                if (signal[i].Equals(signal[i + 1]) || signal[i].Equals(signal[i + 2])) outSignal += signal[i];
                else outSignal += signal[i + 1]; 
                
            }
            Console.WriteLine("Расшифрованный сигнал : " + outSignal);
        }
    }
}
