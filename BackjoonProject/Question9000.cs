using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static BackjoonProject.Tools;
using static System.Console;

namespace BackjoonProject
{
    class Question9000
    {
        public void Q9009()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int T = int.Parse(reader.ReadLine());
            List<int> f = new List<int>();
            // 피보나치 정의를 사용하기 위해 0과 1은 미리 입력
            f.Add(0);
            f.Add(1);

            int index = 2;
            while (true)
            {
                int value = f[index - 1] + f[index - 2]; // 피보나치 계산
                if (value > 1000000000) // 조건에 따라 해당 하는 값보다 크다면 무의미
                    break;

                f.Add(f[index - 1] + f[index - 2]); // 계산한 값을 f리스트에 저장
                index++;
            }

            List<int> result = new List<int>();
            int count = f.Count;
            for (int i = 0; i < T; i++)
            {
                int input = int.Parse(reader.ReadLine());
                int listIndex = count - 1; // 피보나치 제일 큰 수부터 index 설정

                while (input > 0) // 입력 받은 값보다 작아지면 반복문 탈출
                {
                    for (int j = listIndex; j > -1; j--) // 피보나치의 제일 큰 수부터 시작
                    {
                        // 입력 받은 값에 피보나치 값을 빼서 나온 값이 0보다 크다면 더할 수 있다.
                        // 0보다 작다면 더할 수 없는 값
                        if (input - f[j] >= 0)
                        {
                            result.Add(f[j]);
                            input -= f[j];
                        }
                    }
                }

                int last = result.Count - 1;

                // 제일 작은 수부터 출력
                for (int j = last - 1; j >= 0; j--)
                    writer.Write(result[j] + " ");

                writer.WriteLine();
                result.Clear();
            }

            writer.Close();
            reader.Close();
        }

        public void Q9012()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int T = int.Parse(reader.ReadLine());
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < T; i++)
                writer.WriteLine(FindVPS());

            writer.Close();
            reader.Close();

            string FindVPS()
            {
                stack.Clear();
                string str = reader.ReadLine();

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '(')
                        stack.Push(str[j]);
                    else
                    {
                        if (stack.TryPop(out char value))
                        {
                            if (value == ')')
                                return "NO";
                        }
                        else
                            return "NO";

                    }
                }

                if (stack.Count > 0)
                    return "NO";

                return "YES";
            }
        }

        public void Q9020()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = Eratosthenes(10000 + 1);

            int t = int.Parse(reader.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(reader.ReadLine());
                int a = n / 2;
                int b = n / 2;

                while (true)
                {
                    if (primeNum[a] != 0 && primeNum[b] != 0)
                    {
                        writer.WriteLine($"{primeNum[a]} {primeNum[b]}");
                        break;
                    }

                    a--;
                    b++;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q9184()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[,,] dp = new int[21, 21, 21];
            while (true)
            {
                int[] N = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                if (N[0] == -1 && N[1] == -1 && N[2] == -1)
                    break;

                writer.WriteLine($"w({N[0]}, {N[1]}, {N[2]}) = {Result(N[0], N[1], N[2])}");
            }

            writer.Close();
            reader.Close();

            // 동적 프로그래밍
            int Result(int a, int b, int c)
            {
                if (a <= 0 || b <= 0 || c <= 0)
                    return 1;

                if (a > 20 || b > 20 || c > 20)
                    return Result(20, 20, 20);

                // 이미 계산된 값이라면 계산하지 않고 리턴
                if (dp[a, b, c] != 0)
                    return dp[a, b, c];

                if (a < b && b < c)
                {
                    dp[a, b, c] = Result(a, b, c - 1) + Result(a, b - 1, c - 1)
                        - Result(a, b - 1, c);
                    return dp[a, b, c];
                }

                dp[a, b, c] = Result(a - 1, b, c) + Result(a - 1, b - 1, c)
                    + Result(a - 1, b, c - 1) - Result(a - 1, b - 1, c - 1);
                return dp[a, b, c];
            }

            // 재귀함수
            int W(int a, int b, int c)
            {
                if (a <= 0 || b <= 0 || c <= 0)
                    return 1;

                if (a > 20 || b > 20 || c > 20)
                    return W(20, 20, 20);

                if (a < b && b < c)
                    return W(a, b, c - 1) + W(a, b - 1, c - 1) - W(a, b - 1, c);

                return W(a - 1, b, c) + W(a - 1, b - 1, c)
                    + W(a - 1, b, c - 1) - W(a - 1, b - 1, c - 1);
            }
        }

        public void Q9237()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int[] tree = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int[] day = new int[N];

            // 내림 차순 정렬
            Array.Sort(tree);
            Array.Reverse(tree);

            for (int i = 0; i < N; i++)
                day[i] = i + 1 + tree[i]; // 나무가 자라는데 걸리는 시간

            writer.WriteLine(day.Max() + 1); // 최고로 오래걸리는 나무시간 + 첫날 심는 시간

            writer.Close();
            reader.Close();
        }

        public void Q9498()
        {
            int grade = int.Parse(Console.ReadLine());

            if (90 <= grade && grade <= 100)
                Console.WriteLine("A");
            else if (80 <= grade && grade <= 89)
                Console.WriteLine("B");
            else if (70 <= grade && grade <= 79)
                Console.WriteLine("C");
            else if (60 <= grade && grade <= 69)
                Console.WriteLine("D");
            else
                Console.WriteLine("F");
        }
    }
}
