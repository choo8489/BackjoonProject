using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    internal class Retry
    {
        public void Q13458()
        {
            // 13458
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine()); // 시험장의 갯수
            int[] A = Array.ConvertAll(reader.ReadLine().Split(), int.Parse); // 각 시험장에서의 응시자의 수
            string[] input = reader.ReadLine().Split();

            int B = int.Parse(input[0]); // 총감독관이 감시할 수 있는 응시자의 수
            int C = int.Parse(input[1]); // 부감독관이 감시할 수 있는 응시자의 수

            long result = N;
            long remainder = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] - B > 0)
                    remainder = (A[i] - B); // 나머지 수

                result += remainder / C;

                if (remainder % C > 0)
                    result++;
            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

    }
}
