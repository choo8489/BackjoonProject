using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static System.Console;

namespace BackjoonProject
{
    class Question4000
    {
        public void Q4153()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            while (true)
            {
                int[] value = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                if (value[0] == 0 && value[1] == 0 && value[2] == 0)
                    break;

                Array.Sort(value);

                int a = value[2] * value[2];
                int b = value[0] * value[0] + value[1] * value[1];

                if (a == b)
                    writer.WriteLine("right");
                else
                    writer.WriteLine("wrong");
            }

            writer.Close();
            reader.Close();
        }
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

        public void Q4796()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int index = 0;

            while (true)
            {
                int sum = 0;
                string[] input = reader.ReadLine().Split();

                int L = int.Parse(input[0]); // P 기간 중 사용할 수 있는 기간
                int P = int.Parse(input[1]); // 캠핑장을 연속하는 기간
                int V = int.Parse(input[2]); // 휴가 기간

                if (L == 0 && P == 0 && V == 0)
                    break;

                sum = (V / P) * L; // V일 자리 휴가에 연속하는 기간 P로 나눈 몫에 L을 곱하면 반드시 써야하는 휴가 기간입니다.
                V %= P; // V일에 휴가기간에서 연속하는 기간을 나눈 나머지는 사용하지 못한 휴가 입니다.
                sum += V < L ? V : L; // 남은 휴가가 L 보다 작다면 그대로 사용하면 되고 크다면 L만큼 밖에 사용하지 못합니다.
                index++;

                writer.WriteLine($"Case {index}: {sum}");
            }

            writer.Close();
            reader.Close();
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

        public void Q4949()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            Stack<char> stack = new Stack<char>();
            bool result;

            while (true)
            {
                string str = reader.ReadLine();

                if (str == ".")
                    break;

                result = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(' || str[i] == '[')
                    {
                        stack.Push(str[i]);
                    }
                    else if (str[i] == ')')
                    {
                        if (stack.Count > 0 && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            result = true;
                            break;
                        }
                    }
                    else if (str[i] == ']')
                    {
                        if (stack.Count > 0 && stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            result = true;
                            break;
                        }
                    }
                }

                if (result || stack.Count > 0)
                    writer.WriteLine("no");
                else
                    writer.WriteLine("yes");

                stack.Clear();
            }

            writer.Close();
            reader.Close();
        }
    }
}
