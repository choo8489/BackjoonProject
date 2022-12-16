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
    class Question10000
    {
        public void Q10039()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                int point = int.Parse(reader.ReadLine());
                sum += (point >= 40) ? point : 40;
            }

            writer.WriteLine(sum / 5);

            writer.Close();
            reader.Close();
        }

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
            // data라는 List 변수를 선언
            List<(int, string)> data = new List<(int, string)>();

            for (int i = 0; i < n; i++)
            {
                string[] value = reader.ReadLine().Split();
                // 튜플을 사용하여 나이와 이름을 저장하였습니다.
                data.Add((int.Parse(value[0]), value[1]));
            }

            // C# 문법 LINQ(OrderBy)로 정렬
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

        public void Q10817()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            Array.Sort(input); // 오름차순으로 정렬

            writer.WriteLine(input[1]); // 두번째로 큰 정수 출력

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

        public void Q10844()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());

            BigInteger[,] dp = new BigInteger[N + 1, 10];

            for (int i = 0; i < 10; i++)
                dp[1, i] = 1;

            for (int i = 2; i < N + 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                        dp[i, j] = dp[i - 1, 1];
                    else if (j == 9)
                        dp[i, j] = dp[i - 1, 8];
                    else
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];

                    //dp[i, j] %= 1000000000;
                }
            }

            BigInteger sum = 0;

            for (int i = 1; i < 10; i++)
                sum += dp[N, i];


            writer.WriteLine(sum % 1000000000); //  % 1000000000

            writer.Close();
            reader.Close();
        }

        public void Q10844_2()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());

            long[,] dp = new long[N + 1, 10];

            for (int i = 0; i < 10; i++)
                dp[1, i] = 1;

            for (int i = 2; i < N + 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                        dp[i, j] = dp[i - 1, 1];
                    else if (j == 9)
                        dp[i, j] = dp[i - 1, 8];
                    else
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];

                    dp[i, j] %= 1000000000;
                }
            }

            long sum = 0;

            for (int i = 1; i < 10; i++)
            {
                sum += dp[N, i];
            }

            writer.WriteLine(sum % 1000000000); //  % 1000000000

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

        public void Q10953()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int T = int.Parse(reader.ReadLine());

            for (int i = 0; i < T; i++)
            {
                string input = reader.ReadLine();
                // 0 = A
                // 1 = ,
                // 2 = B
                // 0번째 char랑 2번째 char를 더해주면 A+B의 합을 구할 수 있습니다.
                writer.WriteLine(int.Parse(input[0].ToString()) + int.Parse(input[2].ToString()));
            }

            writer.Close();
            reader.Close();
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

        public void Q11053()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int[] dp = new int[N];

            for (int i = 0; i < N; i++)
            {
                dp[i] = 1;

                for (int j = 0; j < i; j++)
                {
                    // 선택된 수열에 앞에 값보다 크고
                    // 저장된 수열의 갯수를 늘려주며 현재 선택된 수열의 길이를 변경
                    if (input[j] < input[i] && dp[i] < dp[j] + 1)
                        dp[i] = dp[j] + 1;
                }
            }

            // dp[0] = 1 (10)
            // dp[1] = 2 (10,20)
            // dp[2] = 1 (10)
            // dp[3] = 3 (10,20,30)
            // dp[4] = 2 (10,20)
            // dp[5] = 4 (10,20,30,50)

            int max = dp[0];

            // 가장 긴 수열의 길이를 찾아야 합니다.
            for (int i = 1; i < N; i++)
            {
                if (max < dp[i])
                    max = dp[i];
            }

            writer.WriteLine(max);

            writer.Close();
            reader.Close();
        }

        public void Q11399()
        {
            // 11399 그리디 알고리즘 / 정렬
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            // 합의 최솟값이라 하면 제일 돈을 인출하는데 걸리는 시간이 적은 사람부터 진행해야 
            // 시간의 합이 최솟값입니다.
            int N = int.Parse(reader.ReadLine()); // 사람의 수
            int[] P = Array.ConvertAll(reader.ReadLine().Split(), int.Parse); // 돈을 인출하는데 걸리는 시간 Pi
            int[] accrueP = new int[N]; // 누적 시간 

            Array.Sort(P); // 내림차순 정렬

            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += P[i];
                accrueP[i] = sum; // 돈을 인출 할 때 걸리는 시간을 누적하여 저장
            }

            writer.WriteLine(accrueP.Sum()); // 합의 최솟값

            writer.Close();
            reader.Close();
        }

        public void Q11508()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int[] dairy = new int[N];

            for (int i = 0; i < N; i++)
                dairy[i] = int.Parse(reader.ReadLine());

            // 내림차순으로 정렬
            Array.Sort(dairy);
            Array.Reverse(dairy);

            int cost = 0;
            for (int i = 0; i < N; i++)
            {
                if (i % 3 == 2) // 세번째 값은 cost에 더하지 않고 패스
                    continue;

                cost += dairy[i];
            }

            writer.WriteLine(cost);

            writer.Close();
            reader.Close();
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

        public void Q11651()
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
            //var sortList = list.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
            var sortList = list.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToList();

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
        
        public void Q13413()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int T = int.Parse(reader.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(reader.ReadLine());
                char[] input = reader.ReadLine().ToCharArray();
                char[] goal = reader.ReadLine().ToCharArray();

                int countW = 0;
                int countB = 0;

                for (int j = 0; j < N; j++)
                {
                    if (input[j] != goal[j]) // 입력받은 데이터와 목표로 하는 데이터가 같지 않을 경우
                    {
                        if (goal[j] == 'W') // 목표로 하는 값이 W 라면
                            countW++; // W 카운터 증가
                        else
                            countB++; // B 카운터 증가
                    }
                }

                // W카운터와 B 카운터 중 큰 카운터수를 출력
                writer.WriteLine((countW > countB) ? countW : countB);
            }

            writer.Close();
            reader.Close();
        }

        public void Q13413_1()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int T = int.Parse(reader.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(reader.ReadLine());
                char[] input = reader.ReadLine().ToCharArray();
                char[] goal = reader.ReadLine().ToCharArray();

                int countW = 0;
                int countB = 0;

                for (int j = 0; j < N; j++)
                {
                    if (input[j] != goal[j]) // 입력받은 데이터와 목표로 하는 데이터가 같지 않을 경우
                    {
                        if (input[j] == 'W') // 목표로 하는 값이 W 라면
                            countW++; // W 카운터 증가
                        else
                            countB++; // B 카운터 증가
                    }
                }

                int count = 0;
                while (countW > 0 && countB > 0)
                {
                    countW--;
                    countB--;
                    count++;
                }

                // W카운터와 B 카운터 중 큰 카운터수를 출력
                writer.WriteLine(countW + countB + count);
            }

            writer.Close();
            reader.Close();
        }

        public void Q13417()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int T = int.Parse(reader.ReadLine());
            List<char> result = new List<char>();

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(reader.ReadLine());
                char[] input = Array.ConvertAll(reader.ReadLine().Split(), char.Parse);

                result.Add(input[0]);

                for (int j = 1; j < N; j++)
                {
                    if (result[0] >= input[j])
                        result.Insert(0, input[j]);
                    else
                        result.Add(input[j]);
                }

                foreach (var o in result)
                    writer.Write(o);

                writer.WriteLine();
                result.Clear();
            }

            writer.Close();
            reader.Close();
        }

        public void Q14469()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            List<(int, int)> cows = new List<(int, int)>();

            for (int i = 0; i < N; i++)
            {
                string[] input = reader.ReadLine().Split();
                cows.Add((int.Parse(input[0]), int.Parse(input[1]))); // 도착시간과 검문시간 입력
            }

            cows = cows.OrderBy(time => time.Item1).ToList(); // 도착시간을 가지고 오름차순 정렬
            int minTime = cows[0].Item1 + cows[0].Item2; // 처음값은 대기시간이 없으므로 바로 입력

            for (int i = 1; i < N; i++)
            {
                if (minTime <= cows[i].Item1) // 기다리는 시간이 없으면 도착시간 + 검문시간
                    minTime = cows[i].Item1 + cows[i].Item2;
                else // 기다리는 시간이 있기 때문에 기다린시간 + 검문시간
                    minTime += cows[i].Item2;
            }

            writer.WriteLine(minTime);

            writer.Close();
            reader.Close();
        }

        public void Q14659()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int[] height = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int count = 0; // 현재 봉우리의 킬수
            int max = height[0]; // 처음 첫번째 봉우리의 높이 값을 초기화
            int kill = 0; // 최대 킬수 저장

            for (int i = 1; i < N; i++)
            {
                if (count > kill) // 현재 봉우리의 킬수가 최대 킬수보다 크다면 그 값을 저장
                    kill = count;

                if (height[i] > max) // 현재 봉우리의 값이 max보다 크다면 킬 카운팅을 초기화
                {
                    max = height[i];
                    count = 0;
                }
                else
                {
                    count++; // 킬 카운터 추가
                }
            }

            if (count > kill) // 마지막 값이 count++ 하고 넘어가는 경우가 있어 한번더 검사
                kill = count;

            writer.WriteLine(kill);

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

        public void Q14720()
        {
            // 14720 우유축제
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            string[] input2 = reader.ReadLine().Split();
            int count = 0;
            int nowMilk = 0;

            for (int i = 0; i < N; i++)
            {
                int milk = int.Parse(input2[i]); // 현재 우유 가게 정보 가지고오기

                if (milk == nowMilk) // 현재 먹어야하는 우유 확인
                {
                    count++; // 먹은 우유 개수 카운팅
                    nowMilk = (nowMilk == 2) ? 0 : ++nowMilk; // 우유 순환, 마지막 바나나우유를 먹었으면 딸기 우유로 변경
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
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

        public void Q15649()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            int[] result = new int[9];
            bool[] visited = new bool[9];

            DFS(0);

            writer.Close();
            reader.Close();

            void DFS(int count)
            {
                if (count == M)
                {
                    // 카운트가 M만큼 된다면 출력 
                    for (int i = 0; i < M; i++)
                        writer.Write($"{result[i]} ");
                    writer.WriteLine();
                }
                else
                {
                    for (int i = 1; i <= N; i++)
                    {
                        // 뽑은 숫자의 방문 유무를 저장
                        if (!visited[i])
                        {
                            visited[i] = true;
                            result[count] = i;
                            DFS(count + 1);
                            visited[i] = false;
                        }
                    }
                }
            }
        }

        public void Q15829()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int l = int.Parse(reader.ReadLine());
            string str = reader.ReadLine();

            long result = 0;
            long R = 1;
            long MOD = 1234567891;

            for (int i = 0; i < l; i++)
            {
                result += ((int)str[i] - 'a' + 1) * R;

                // 덧셈하는 과정에서 소수 M으로 나누어 줘야 값이 너무 커지지 않습니다.
                // (a + b) mod n = {(a mod n) + (b mod n)} mod n
                result %= MOD;

                R *= 31;
                R %= MOD;
            }


            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q15904()
        {
            // 15904 UCPC는 무엇의 약자일까?
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            char[] input = reader.ReadLine().ToCharArray();
            int count = 0;

            string str = "UCPC";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == str[count]) // count를 하나씩 올려주며 UCPC가 있는지 확인
                {
                    count++;

                    if (count == 4) // UCPC가 다 있으면 종료
                        break;
                }
            }

            if (count == 4)
                writer.WriteLine("I love UCPC");
            else
                writer.WriteLine("I hate UCPC");

            writer.Close();
            reader.Close();
        }

        public void Q16435()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            string[] input2 = reader.ReadLine().Split();

            int N = int.Parse(input[0]);
            int L = int.Parse(input[1]);
            int[] H = new int[N];

            for (int i = 0; i < N; i++)
                H[i] = int.Parse(input2[i]);

            // 자신의 길이보다 작거나 같은 높이 부터 먹기위에 오름차순으로 정렬
            Array.Sort(H);

            for (int i = 0; i < N; i++)
            {
                if (L >= H[i]) // 먹을 수 있는지 확인
                    L++;
                else // 못먹으면 반복문 종료
                    break;
            }

            writer.WriteLine(L);

            writer.Close();
            reader.Close();
        }

        public void Q17219()
        {
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]); // 저장된 사이트의 주소
            int m = int.Parse(input[1]); // 비밀번호를 찾으려는 사이트 주소의 수

            // 리스트로 했을 때 82%에서 통과하지 못했습니다. ( 시간초과로 )
            //List<(string, string)> map = new List<(string, string)>();
            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                input = reader.ReadLine().Split();
                map.Add(input[0], input[1]);
            }

            string email;
            for (int j = 0; j < m; j++)
            {
                email = reader.ReadLine();
                // 리스트로 찾을 때
                //builder.Append($"{(map.Find(o => o.Item1 == email)).Item2}\n");
                builder.Append($"{map[email]}\n");
            }

            writer.WriteLine(builder);

            writer.Close();
            reader.Close();
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

        public void Q18111()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int b = int.Parse(input[2]);

            int[,] block = new int[n, m];

            int min = 256, max = 0;

            for (int i = 0; i < n; i++)
            {
                int[] mValue = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                for (int j = 0; j < m; j++)
                {
                    block[i, j] = mValue[j]; // 블럭 할당
                    if (min > mValue[j])
                        min = mValue[j]; // 블럭의 높이 min 값
                    if (max < mValue[j])
                        max = mValue[j]; // 블럭의 높이 max 값
                }
            }

            int remove, build, time;
            int minTime = 256 * n * m * 2;
            int maxHeight = 0;

            for (int i = min; i <= max; i++)
            {
                remove = 0;
                build = 0;

                // min 부터 max 까지 빼야될 거랑 추가할 갯수를 구합니다.
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < m; y++)
                    {
                        int height = block[x, y] - i;

                        if (height > 0)
                            remove += height;
                        else if (height < 0)
                            build -= height;
                    }
                }

                // 더 해야될 갯수 <= 빼야될 갯수 + 가지고 있는 갯수만 평평해질 수 있다.
                if (build <= remove + b)
                {
                    // 시간 계산 빼는거 * 2 + 더해야될 거
                    time = remove * 2 + build;

                    // 시간이 min보다 작다면 교체
                    if (time <= minTime)
                    {
                        minTime = time;
                        maxHeight = i;
                    }
                }
            }

            writer.WriteLine($"{minTime} {maxHeight}");

            writer.Close();
            reader.Close();
        }

        public void Q19939()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);

            // 등차수열의 합
            // 1부터 K까지의 총합
            int sum = K * (K + 1) / 2;

            if (N < sum) // 필요한 박의 개수가 N보다 크다면 -1 출력
                writer.WriteLine(-1);
            else if ((N - sum) % K == 0) // 동일한 개수로 분배를 할 수 있다면 제일 큰수와 제일 작은수의 차이는 K-1이 됩니다.
                writer.WriteLine(K - 1);
            else
                writer.WriteLine(K); // 그게 아니라면 제일 큰수와 작은수는 K개 만큼 차이납니다.

            writer.Close();
            reader.Close();
        }


    }
}
