using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    static class Tools
    {
        static public int[] Eratosthenes(int max)
        {
            int[] primeNum = new int[max + 1];

            for (int i = 2; i < max; i++)
                primeNum[i] = i;

            float num = MathF.Sqrt(max);
            for (int i = 2; i <= num; i++)
            {
                if (primeNum[i] == 0)
                    continue;

                for (int j = i * i; j <= max; j += i)
                    primeNum[j] = 0;
            }

            return primeNum;
        }

        static public int Fibonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
