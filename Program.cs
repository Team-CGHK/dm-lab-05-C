using System;
using System.IO;

namespace DiscreteMathLab5_C
{
    class Program
    {
        static StreamReader sr = new StreamReader("num2choose.in");
        static StreamWriter sw = new StreamWriter("num2choose.out");

        static void Main(string[] args)
        {
            string[] parts = sr.ReadLine().Split(' ');
            int n = int.Parse(parts[0]),
                k = int.Parse(parts[1]);
            long m = int.Parse(parts[2]);
            int[] result = GetChooseByNumber(n, k, m);
            for (int i = 0; i < k; i++)
            {
                sw.Write(result[i] + " ");
            }
            sw.Close();
        }

        static int[] GetChooseByNumber(int n, int k, long number)
        {
            int[] set = new int[n];
            for (int i = 0; i < n; i++)
                set[i] = i + 1;
            int[] choose = new int[k];
            int pos = 0;
            while (pos < k)
            {
                int delta = 0;
                int nn = set.Length-1;
                while (number - C(nn, k - pos - 1) >= 0)
                {
                    number -= C(nn--, k - pos - 1);
                    delta++;
                }
                choose[pos] = set[delta];
                int[] nextset = new int[set.Length - delta - 1];
                int j = 0;
                for (long i = delta + 1; i < set.Length; i++)
                     nextset[i-delta-1] = set[i];
                set = nextset;
                pos++;
            }
            return choose;
        }

        static long C(int n, int k)
        {
            double divident = 1;
            int j = 2;
            for (int i = 0; i < k; i++)
            {
                divident *= n - i;
                if (j <= k) divident /= j++;
            }
            for ( ; j<=k; j++)
                divident /= j++;
            return (long)Math.Round(divident);
        }
    }
}
