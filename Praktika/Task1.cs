using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Praktika
{
    class Task1
    {
            public static int K;
            public static int S;
            public static double max;
            public static double min;
            static void Trans(string Str)
            {
                string[] MStr = Str.Split(' ');
                S = Int32.Parse(MStr[0]);
                K = Int32.Parse(MStr[1]);
            }
            static void Read()
            {
                FileInfo File = new FileInfo("INPUT.TXT");
                StreamReader Input = File.OpenText();
                string Str = Input.ReadLine();
                Input.Close();
                Trans(Str);
            }
            static void Write()
            {
                FileInfo File = new FileInfo("OUTPUT.TXT");
                StreamWriter Output = File.CreateText();
                Output.Write(max + " ");
                Output.Write(min);
                Output.Close();
            }
            static void Min(double stepen)
            {
                double t = S - 1;
                min = stepen;
                double k = 1;
                while (t >= 9)
                {
                    t -= 9;
                    min += k * 9;
                    k *= 10;
                }
                min += t * k;
            }
            static void Max(double stepen)
            {
                double t = S - 9;
                max = stepen * 9;
                while (t >= 9)
                {
                    stepen /= 10;
                    max += stepen * 9;
                    t -= 9;
                }
                max += stepen / 10 * t;
            }
            public static void Launch()
            {
                Read();
                int p = S;
                double stepen = Math.Pow(10, K - 1);
                if (S == 1)
                {
                    max = stepen;
                    min = stepen;
                }
                else if (S < 10)
                {
                    min = stepen + S - 1;
                    max = stepen * S;
                }
                else
                {
                    Min(stepen);
                    Max(stepen);
                }
                Write();
        }
    }
}
