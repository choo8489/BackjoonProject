﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Question10000
    {
        public void Q10172()
        {
            Console.WriteLine("|\\_/|");
            Console.WriteLine("|q p|   /}");
            Console.WriteLine("( 0 )\"\"\"\\");
            Console.WriteLine("|\"^\"`    |");
            Console.WriteLine("||_/=\\\\__|");
        }

        public void Q10250()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int t = int.Parse(reader.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                int h = data[0];
                int w = data[1];
                int n = data[2];

                int cnt = 0;

                for (int j = 1; j <= w; j++)
                {
                    for (int z = 1; z <= h; z++)
                    {
                        cnt++;

                        if (n == cnt)
                        {
                            writer.WriteLine($"{z}{j:00}");
                            break;
                        }
                    }

                    if (n == cnt)
                        break;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q10434()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine((data[0] + data[1]) % data[2]);
            Console.WriteLine(((data[0] % data[2]) + (data[1] % data[2])) % data[2]);
            Console.WriteLine((data[0] * data[1]) % data[2]);
            Console.WriteLine(((data[0] % data[2]) * (data[1] % data[2])) % data[2]);
        }

        public void Q10757()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] str = reader.ReadLine().Split();

            float max = MathF.Max(str[0].Length, str[1].Length);

            int[] a = new int[(int)max + 1];
            int[] b = new int[(int)max + 1];

            for (int i = str[0].Length - 1, j = 0; i >= 0; i--, j++)
                a[j] = int.Parse(str[0][i].ToString());

            for (int i = str[1].Length - 1, j = 0; i >= 0; i--, j++)
                b[j] = int.Parse(str[1][i].ToString());

            for (int i = 0; i < (int)max; i++)
            {
                int value = a[i] + b[i];
                a[i] = value % 10;
                a[i + 1] += (value / 10);
            }

            if (a[(int)max] != 0)
                writer.Write(a[(int)max]);

            for (int i = (int)max - 1; i >= 0; i--)
                writer.Write(a[i]);

            writer.Close();
            reader.Close();
        }

        public void Q10773()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int k = int.Parse(reader.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < k; i++)
            {
                int num = int.Parse(reader.ReadLine());
                if (num == 0)
                    stack.Pop();
                else
                    stack.Push(num);
            }

            writer.WriteLine(stack.Sum());

            writer.Close();
            reader.Close();
        }

        public void Q10814()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<(int, string)> data = new List<(int, string)>();

            for (int i = 0; i < n; i++)
            {
                string[] value = reader.ReadLine().Split();

                data.Add((int.Parse(value[0]), value[1]));
            }

            // C# 문법 LINQ 로 정렬
            var sortList = data.OrderBy(x => x.Item1).ToList();

            for (int i = 0; i < n; i++)
                writer.WriteLine($"{sortList[i].Item1} {sortList[i].Item2}");

            writer.Close();
            reader.Close();
        }

        public void Q10816()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            string[] str = reader.ReadLine().Split();
            int[] x = new int[20000001]; // 음수 + 양수

            // 카운트 소팅
            for (int i = 0; i < n; i++)
                x[10000000 + int.Parse(str[i])]++;

            int m = int.Parse(reader.ReadLine());
            string[] str2 = reader.ReadLine().Split();
            int[] y = new int[m];

            for (int i = 0; i < m; i++)
                y[i] = int.Parse(str2[i]);

            for (int i = 0; i < m; i++)
                writer.Write($"{x[10000000 + y[i]]} ");

            writer.Close();
            reader.Close();
        }

        public void Q10818()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            using (StringReader reader = new StringReader(Console.ReadLine()))
            {
                List<int> text = (Array.ConvertAll(reader.ReadLine().Split(), int.Parse)).ToList();

                builder.Append($"{text.Min()} {text.Max()}");
            }

            Console.WriteLine(builder);
        }

        public void Q10828()
        {
            // List로 Stack 구현
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<int> stack = new List<int>();

            int n = int.Parse(reader.ReadLine());

            string[] push = new string[2];
            string str;
            for (int i = 0; i < n; i++)
            {
                str = reader.ReadLine();

                if (str.Contains("push"))
                    push = str.Split();

                switch (str)
                {
                    case "top":
                        if (stack.Count > 0)
                            writer.WriteLine(stack.Last());
                        else
                            writer.WriteLine(-1);
                        break;
                    case "pop":
                        if (stack.Count > 0)
                        {
                            writer.WriteLine(stack.Last());
                            stack.RemoveAt(stack.Count - 1);
                        }
                        else
                        {
                            writer.WriteLine(-1);
                        }
                        break;
                    case "size":
                        writer.WriteLine(stack.Count);
                        break;
                    case "empty":
                        writer.WriteLine((stack.Count == 0) ? 1 : 0);
                        break;
                    default:
                        stack.Add(int.Parse(push[1].ToString()));
                        break;
                }
            }


            writer.Close();
            reader.Close();
        }

        public void Q10845()
        {
            // List로 Queue 구현
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<int> queue = new List<int>();

            int n = int.Parse(reader.ReadLine());

            string[] push = new string[2];
            string str;
            for (int i = 0; i < n; i++)
            {
                str = reader.ReadLine();

                if (str.Contains("push"))
                    push = str.Split();

                switch (str)
                {
                    case "back":
                        if (queue.Count > 0)
                            writer.WriteLine(queue.Last());
                        else
                            writer.WriteLine(-1);
                        break;
                    case "front":
                        if (queue.Count > 0)
                            writer.WriteLine(queue[0]);
                        else
                            writer.WriteLine(-1);
                        break;
                    case "pop":
                        if (queue.Count > 0)
                        {
                            writer.WriteLine(queue[0]);
                            queue.RemoveAt(0);
                        }
                        else
                        {
                            writer.WriteLine(-1);
                        }
                        break;
                    case "size":
                        writer.WriteLine(queue.Count);
                        break;
                    case "empty":
                        writer.WriteLine((queue.Count == 0) ? 1 : 0);
                        break;
                    default:
                        queue.Add(int.Parse(push[1].ToString()));
                        break;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q10866()
        {
            // List로 Deque 구현
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<int> Deque = new List<int>();

            int n = int.Parse(reader.ReadLine());

            string[] push = new string[2];
            string str;
            for (int i = 0; i < n; i++)
            {
                str = reader.ReadLine();

                if (str.Contains("push"))
                {
                    push = str.Split();
                    str = push[0].ToString();
                }

                switch (str)
                {
                    case "push_front":
                        Deque.Insert(0, int.Parse(push[1].ToString()));
                        break;
                    case "push_back":
                        Deque.Add(int.Parse(push[1].ToString()));
                        break;
                    case "pop_back":
                        if (Deque.Count > 0)
                        {
                            writer.WriteLine(Deque.Last());
                            Deque.RemoveAt(Deque.Count - 1);
                        }
                        else
                            writer.WriteLine(-1);
                        break;
                    case "pop_front":
                        if (Deque.Count > 0)
                        {
                            writer.WriteLine(Deque[0]);
                            Deque.RemoveAt(0);
                        }
                        else
                        {
                            writer.WriteLine(-1);
                        }
                        break;
                    case "size":
                        writer.WriteLine(Deque.Count);
                        break;
                    case "empty":
                        writer.WriteLine((Deque.Count == 0) ? 1 : 0);
                        break;
                    case "front":
                        if (Deque.Count > 0)
                            writer.WriteLine(Deque[0]);
                        else
                            writer.WriteLine(-1);
                        break;
                    case "back":
                        if (Deque.Count > 0)
                            writer.WriteLine(Deque.Last());
                        else
                            writer.WriteLine(-1);
                        break;
                    default:
                        break;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q10869()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(A[0] + A[1]);
            Console.WriteLine(A[0] - A[1]);
            Console.WriteLine(A[0] * A[1]);
            Console.WriteLine(A[0] / A[1]);
            Console.WriteLine(A[0] % A[1]);
        }

        public void Q10870()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int result = 0;
            result += Fibonacci(n);

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q10871()
        {
            StringBuilder builder = new StringBuilder();

            int[] text = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int i = 0; i < text[0]; i++)
            {
                if (text[1] > value[i])
                    builder.Append($"{value[i]} ");
            }
            builder.Append("\n");

            Console.WriteLine(builder);
        }

        public void Q10872()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(ReadLine());
            int sum = 1;
            Factorial(n);

            writer.WriteLine(sum);

            writer.Close();
            reader.Close();

            int Factorial(int n)
            {

                if (n == 0)
                    return 0;

                sum *= n;

                return Factorial(n - 1);
            }
        }

        public void Q10926()
        {
            string id = Console.ReadLine();
            Console.WriteLine($"{id}??!");
        }

        public void Q10950()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                Console.WriteLine(data[0] + data[1]);
            }
        }

        public void Q10951()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == null)
                    break;

                int[] text = Array.ConvertAll(input.Split(), int.Parse);
                Console.WriteLine(text[0] + text[1]);
            }
        }

        public void Q10952()
        {
            while (true)
            {
                string input = Console.ReadLine();

                int[] text = Array.ConvertAll(input.Split(), int.Parse);

                if (text[0] == 0 && text[1] == 0)
                    break;

                Console.WriteLine(text[0] + text[1]);
            }
        }

        public void Q10989()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int[] nArray = new int[10001];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(reader.ReadLine());
                nArray[num]++;
            }

            for (int i = 0; i < 10001; i++)
                for (int j = 0; j < nArray[i]; j++)
                    writer.WriteLine(i);

            writer.Close();
            reader.Close();
        }

        public void Q10998()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(A[0] * A[1]);
        }

        public void Q11021()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"Case #{i + 1}: {text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q11022()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"Case #{i + 1}: {text[0]} + {text[1]} = {text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q11050()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] str = reader.ReadLine().Split();
            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);

            // 전체 집합에서 원소의 개수 n에 대해 k개의 아이템을 뽑는 이항계수(조합의 수)는 다음과 같다.
            // (n k) = nCk = n! / (n-k)!*k! (단, 0<=k<=n)
            int result = Factorial(n) / (Factorial(n - k) * Factorial(k));

            writer.WriteLine(result);

            writer.Close();
            reader.Close();

            int Factorial(int n)
            {
                if (n == 0)
                    return 1;
                else
                    return n * Factorial(n - 1);
            }
        }

        public void Q11050_1()
        {
            // 이항계수의 성질
            // (n k) = (n n-k) => n개 중에서 k개를 간택하는 것은 선택받지 못할 나머지 (n-k)개를 선택하는 것과 같다.
            // 성질 1
            // 2^n = nC0 + nC1 + nC2 + ... + nCn
            // 2^n - 1 = nC1 + nC2 + ... + nCn
            // 성질2
            // nC1 + nC3 + nC5 + ... = nC0 + nC2 + nC4 + ...
            // 홀수 = 짝수 => 홀수 = 2^n-1  짝수 = 2^n-1
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());


            string[] str = reader.ReadLine().Split();
            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);

            writer.WriteLine(Binomial(n, k));

            writer.Close();
            reader.Close();

            int Binomial(int n, int k)
            {
                // 파스칼 삼각형
                if (n == k || k == 0)
                    return 1;

                // n-1Ck-1 까지의 합과 n-1Ck까지의 합을 더한 값
                return Binomial(n - 1, k - 1) + Binomial(n - 1, k);
            }
        }

        public void Q11650()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < n; i++)
            {
                string[] str = reader.ReadLine().Split();
                int x = int.Parse(str[0].ToString());
                int y = int.Parse(str[1].ToString());
                list.Add((x, y));
            }

            // x 좌표로 정렬하고, y좌표로 정렬
            var sortList = list.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            //var sortList = (from data in list
            //                orderby data.Item1, data.Item2
            //                select data).ToList();

            for (int i = 0; i < n; i++)
                writer.WriteLine($"{sortList[i].Item1} {sortList[i].Item2}");

            writer.Close();
            reader.Close();
        }

        public void Q11653()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> result = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    result.Add(i);
                    n /= i;
                }
            }

            int count = result.Count;

            for (int i = 0; i < count; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();
        }

        public void Q11654()
        {
            string str = Console.ReadLine();

            Console.WriteLine((int)str[0]);
        }

        public void Q11720()
        {
            int n = int.Parse(Console.ReadLine());

            char[] c = Console.ReadLine().ToCharArray();

            int length = c.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(c[i].ToString());
            }

            Console.WriteLine(sum);
        }

        public void Q11729()
        {
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int cnt = 0;

            Recursion(n, 1, 2, 3);

            writer.WriteLine(cnt);

            writer.WriteLine(builder);

            reader.Close();
            writer.Close();

            void Recursion(int n, int from, int mid, int to)
            {
                if (n == 1)
                {
                    builder.AppendLine($"{from} {to}");
                    cnt++;
                }
                else
                {
                    Recursion(n - 1, from, to, mid);

                    builder.AppendLine($"{from} {to}");
                    cnt++;

                    Recursion(n - 1, mid, from, to);
                }
            }
        }

        public void Q11866()
        {
            // 요세푸스 순열
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] str = reader.ReadLine().Split();
            int n = int.Parse(str[0].ToString());
            int k = int.Parse(str[1].ToString());

            List<int> list = new List<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < n; i++)
                list.Add(i + 1);

            // K개 1이 아니라면 체크
            if (k != 1)
            {
                result.Add(list[k - 1]);
                list.RemoveAt(k - 1);
            }

            int index = k - 1;

            while (true)
            {
                if (list.Count == 1)
                {
                    result.Add(list[0]);
                    break;
                }

                // 빼야되는 index의 위치를 찾습니다.
                int count = list.Count;
                for (int i = 1; i < k; i++)
                {
                    index += 1;

                    if (index > count - 1)
                        index = index - count;
                }

                // 빼야되는 index를 result 리스트에 넣어주고 list에서 제거
                result.Add(list[index]);
                list.RemoveAt(index);
            }

            writer.Write("<");
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                    writer.Write($"{result[i]}, ");
                else
                    writer.Write($"{result[i]}>\n");
            }

            writer.Close();
            reader.Close();
        }

        public void Q14681()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
                Console.WriteLine(1);
            else if (x < 0 && y > 0)
                Console.WriteLine(2);
            else if (x < 0 && y < 0)
                Console.WriteLine(3);
            else
                Console.WriteLine(4);
        }

        public void Q15552()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"{text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q17478()
        {
            // 문제를 틀렸습니다. ( 나중에 문제 해결 할예정 )
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int max = n;

            writer.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
            Recursion(n);

            reader.Close();
            writer.Close();

            void Recursion(int n)
            {
                if (n == 0)
                {
                    writer.WriteLine(builder + "\"재귀함수가 뭔가요 ? \"");
                    writer.WriteLine(builder + "\"재귀함수는 자기 자신을 호출하는 함수라네\"");

                    for (int i = 1; i <= max; i++)
                    {
                        writer.WriteLine(builder + "라고 답변하였지.");

                        builder.Remove((max * 4) - (i * 4), 4);
                    }
                    writer.WriteLine("라고 답변하였지.");
                    return;
                }

                writer.WriteLine(builder + "\"재귀함수가 뭔가요 ? \"");
                writer.WriteLine(builder + "\"잘 들어보게.옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
                writer.WriteLine(builder + "마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
                writer.WriteLine(builder + "그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");
                builder.Append("____");

                Recursion(n - 1);
            }
        }

        public void Q18108()
        {
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine($"{y - 543}");
        }

        public void Q25083()
        {
            Console.WriteLine("         ,r'\"7");
            Console.WriteLine("r`-_   ,\'  ,/");
            Console.WriteLine(" \\. \". L_r\'");
            Console.WriteLine("   `~\\/");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
        }
    }
}
