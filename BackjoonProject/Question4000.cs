using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static System.Console;

namespace BackjoonProject
{
    class Question4000
    {
        public void Q4344()
        {
            int c = int.Parse(Console.ReadLine());

            for (int i = 0; i < c; i++)
            {
                int[] grade = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                int sum = 0;
                for (int j = 1; j < grade[0] + 1; j++)
                    sum += grade[j];

                float avg = (float)sum / grade[0];

                int count = 0;
                for (int j = 1; j < grade[0] + 1; j++)
                {
                    if ((float)grade[j] > avg)
                        count++;
                }

                float result = count / (float)grade[0] * 100;

                Console.WriteLine($"{MathF.Round(result, 3):0.000}%");
            }
        }

        public void Q4673()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            int[] cnt = new int[100001];

            for (int i = 1; i < 10000; i++)
                D(i);

            void D(int n)
            {
                char[] ch = n.ToString().ToCharArray();

                int result = n;
                for (int i = 0; i < ch.Length; i++)
                    result += int.Parse(ch[i].ToString());

                cnt[result]++;
            }

            for (int i = 1; i < 10000; i++)
            {
                if (cnt[i] == 0)
                    writer.WriteLine(i);
            }
            writer.Close();
        }

        public void Q4948()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int max = (123456 * 2) + 1;
            int[] primeNum = new int[max];

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

            while (true)
            {
                int n = int.Parse(reader.ReadLine());

                if (n == 0)
                    break;

                int cnt = 0;
                for (int i = n + 1; i <= n * 2; i++)
                {
                    if (primeNum[i] != 0)
                        cnt++;
                }

                writer.WriteLine(cnt);
            }

            writer.Close();
            reader.Close();
        }
    }
}
