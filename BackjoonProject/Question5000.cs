using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Question5000
    {
        public void Q5585()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int money = 1000 - int.Parse(reader.ReadLine());
            int[] change = new int[] { 500, 100, 50, 10, 5, 1 };
            int count = 0;

            for (int i = 0; i < change.Length; i++)
            {
                count += money / change[i]; // 제인 큰 돈부터 나눠주면서 개수를 구합니다.
                money %= change[i]; // 나머지는 받아야되는 돈
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q5622()
        {
            string str = Console.ReadLine();
            int cnt = 0;

            for (int i = 0; i < str.Length; i++)
                cnt += FindNumber(str[i]);

            Console.WriteLine(cnt);

            int FindNumber(int a) =>
                a switch
                {
                    int b when b < 68 => 3,
                    int b when b < 71 => 4,
                    int b when b < 74 => 5,
                    int b when b < 77 => 6,
                    int b when b < 80 => 7,
                    int b when b < 84 => 8,
                    int b when b < 87 => 9,
                    _ => 10,
                };
        }
    }
}
