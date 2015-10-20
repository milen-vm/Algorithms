using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PermutationsIteratively
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());

        int[] perm = Enumerable.Range(1, n).ToArray();
        int[] permHelp = Enumerable.Range(0, n + 1).ToArray();
        int i = 1;

        Console.WriteLine(string.Join(", ", perm));

        while (i < n)
        {
            --permHelp[i];
            int j = (i % 2) != 0 ? permHelp[i] : 0;
            Swap(ref perm[j], ref perm[i]);
            i = 1;
            while (permHelp[i] == 0)
            {
                permHelp[i] = i;
                ++i;
            }

            Console.WriteLine(string.Join(", ", perm));
        }
    }

    private static void Swap(ref int a, ref int b)
    {
        if (a == b)
        {
            return;
        }

        b = a + b;
        a = b - a;
        b = b - a;
    }
}
