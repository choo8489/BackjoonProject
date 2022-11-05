using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    class Question3000
    {
        public void Q3003()
        {
            // 3003
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            // 킹, 퀸, 룩, 비숍, 나이트, 폰
            int[] chess = new int[] { 1, 1, 2, 2, 2, 8 };
            int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            for (int i = 0; i < chess.Length; i++)
            {
                writer.Write($"{chess[i] - input[i]} ");
            }

            writer.Close();
            reader.Close();
        }

        public void Q3046()
        {
            // 3046
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int R1 = int.Parse(input[0]);
            int S = int.Parse(input[1]);

            //(R1+R2)/2 = S
            // (R1+R2) = S*2
            // R2 = (S*2)-R1
            writer.WriteLine((S * 2) - R1);

            writer.Close();
            reader.Close();
        }

        public void Q3052()
        {
            int[] n = new int[43];
            for (int i = 0; i < 10; i++)
                n[int.Parse(Console.ReadLine()) % 42]++;

            int count = 0;
            for (int i = 0; i < 43; i++)
            {
                if (n[i] > 0)
                    count++;
            }

            Console.WriteLine(count);
        }

        public void Q3053()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int R = int.Parse(reader.ReadLine());

            writer.WriteLine($"{R * R * Math.PI:0.000000}");
            writer.WriteLine($"{R * R * 2.0d:0.000000}");

            writer.Close();
            reader.Close();
        }
    }
}
