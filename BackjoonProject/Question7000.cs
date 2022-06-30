using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    class Question7000
    {
        public void Q7568()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int[,] size = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] value = reader.ReadLine().Split();
                size[i, 0] = int.Parse(value[0]);
                size[i, 1] = int.Parse(value[1]);
            }

            int cnt;
            for (int i = 0; i < N; i++)
            {
                cnt = 0;
                for (int j = 0; j < N; j++)
                {
                    if (size[i, 0] < size[j, 0] && size[i, 1] < size[j, 1])
                        cnt++;
                }

                writer.WriteLine(cnt + 1);
            }

            writer.Close();
            reader.Close();
        }
    }
}
