using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    class Question6000
    {
        public void Q6603()
        {
            // 6603
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] lotto = new int[6];
            int k;
            int[] S;

            while (true)
            {
                string[] input = reader.ReadLine().Split();
                k = int.Parse(input[0]);
                S = new int[k];

                if (k == 0)
                    break;

                for (int i = 0; i < k; i++)
                {
                    // 집합 S 변환
                    S[i] = int.Parse(input[i + 1]);
                }

                DFS(0, 0);

                writer.WriteLine();
            }

            writer.Close();
            reader.Close();

            void DFS(int start, int count)
            {
                if (count == 6) // 로또 6개가 다 채워졌을 때
                {
                    for (int i = 0; i < 6; i++)
                    {
                        writer.Write($"{lotto[i]} ");
                    }
                    writer.WriteLine();
                    return;
                }

                for (int i = start; i < k; i++) // 입력 받은 번호를 전부 탐색
                {
                    lotto[count] = (S[i]); // 1개부터 6개까지 집합 S에서 로또 번호를 입력
                    DFS(i + 1, count + 1); // 다음 번호를 입력하는 재귀함수
                }
            }
        }
    }
}
