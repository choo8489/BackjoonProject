using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Fail
    {
        public void Q1025()
        {
            // @@ TODO FAIL %3에서 실패 왠지 sqrt 실패 느낌
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();

            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            char[,] table = new char[10, 10];
            int result = -1;

            for (int i = 0; i < N; i++)
            {
                char[] row = reader.ReadLine().ToCharArray();

                for (int j = 0; j < M; j++)
                    table[i, j] = row[j];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int x = -N + 1; x < N; x++) // 행의 등차 값
                    {
                        for (int y = -M + 1; y < M; y++) // 열의 등차 값
                        {
                            if (y == 0 && y == 0)
                                continue;

                            int dx = i;
                            int dy = j;

                            string str = string.Empty;

                            while (dx >= 0 && dx < N && dy >= 0 && dy < M)
                            {
                                str += table[dx, dy];

                                result = Math.Max(result, ToSqure(int.Parse(str)));
                                dx += x;
                                dy += y;
                            }
                        }
                    }
                }
            }

            if (N == 1 && M == 1)
                writer.WriteLine(ToSqure(int.Parse(table[0, 0].ToString())));
            else
                writer.WriteLine(result);

            int ToSqure(int value)
            {
                var sqrt = (int)Math.Sqrt(value);

                //return (sqrt - Math.Floor(sqrt) == 0) ? value : -1;
                return (sqrt * sqrt == value) ? value : -1;
            }

            writer.Close();
            reader.Close();
        }
    }
}
