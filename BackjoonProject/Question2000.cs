using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static System.Console;

namespace BackjoonProject
{
    class Question2000
    {
        public void Q2108()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> list = new List<int>();

            // 입력되는 정수의 -4000 ~ 4000 까지의 수
            int[] count = new int[8002];

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(reader.ReadLine());
                // 입력받은 값을 List의 넣습니다.
                list.Add(value);
                // 입력받은 값을 카운팅합니다.
                count[value + 4000]++;
            }

            // 총 평균의 소수점이하 반올림
            double avg = Math.Round(list.Average());
            // 산술평균 : N개의 수들의 합을 N으로 나눈 값
            writer.WriteLine((int)avg == -0 ? 0 : avg);

            list.Sort();
            // 중앙값 : N개의 수들을 증가하는 순서로 나열했을 경우 그 중앙에 위치하는 값
            writer.WriteLine(list[(n - 1) / 2]);

            int max = count.Max();
            List<int> mode = new List<int>();
            for (int i = 0; i < 8002; i++)
            {
                // 가장 많이 나타낸 값들을 mode에 넣습니다 ( 중복 까지 )
                if (max == count[i])
                    mode.Add(i - 4000);
            }

            // 가장 많이 나온값을 오름차순으로 정렬
            mode.Sort();
            // 최빈값 : N개의 수들 중 가장 많이 나타나는 값
            if (mode.Count > 1)
                writer.WriteLine(mode[1]);
            else
                writer.WriteLine(mode[0]);

            // 범위 : N개의 수들 중 최댓값과 최솟값의 차이
            writer.WriteLine(list[n - 1] - list[0]);

            writer.Close();
            reader.Close();
        }

        public void Q2163()
        {
            //2163
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();

            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            WriteLine(N * M - 1);

            writer.Close();
            reader.Close();
        }

        public void Q2164()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            Queue<int> queue = new Queue<int>();

            for (int i = 1; i < n + 1; i++)
                queue.Enqueue(i);

            if (!(queue.Count == 1))
            {
                while (true)
                {
                    queue.Dequeue();
                    if (queue.Count == 1)
                        break;
                    int x = queue.Dequeue();
                    queue.Enqueue(x);
                }
            }

            int result = queue.Dequeue();
            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q2178()
        {
            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, 1, 0, -1 };

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];

            int[,] miro = new int[n, m];
            int[,] visited = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string str = reader.ReadLine();

                for (int j = 0; j < m; j++)
                    miro[i, j] = int.Parse(str[j].ToString());
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            visited[0, 0] = 1;

            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = cur.Item1 + dx[dir];
                    int ny = cur.Item2 + dy[dir];

                    if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                        continue;
                    if (visited[nx, ny] == 0 && miro[nx, ny] == 1)
                    {
                        visited[nx, ny] = visited[cur.Item1, cur.Item2] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }

            writer.WriteLine(visited[n - 1, m - 1]);

            writer.Close();
            reader.Close();
        }

        public void Q2204()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<string> input = new List<string>();
            while (true)
            {
                int n = int.Parse(reader.ReadLine()); // 단어의 개수

                // 마지막 입력 확인
                if (n == 0)
                    break;

                for (int i = 0; i < n; i++)
                    input.Add(reader.ReadLine());

                // 입력받은 값을 비교할 때 대문자로 비교해주고 정렬해줍니다.
                input.Sort((x, y) => x.ToUpper().CompareTo(y.ToUpper()));

                writer.WriteLine(input[0]);

                // 전부 비교 후 List 클리어
                input.Clear();
            }

            writer.Close();
            reader.Close();
        }

        public void Q2217()
        {
            static void Main(string[] args)
            {
                StreamWriter writer = new StreamWriter(OpenStandardOutput());
                StreamReader reader = new StreamReader(OpenStandardInput());

                int N = int.Parse(reader.ReadLine());
                int[] w = new int[N];

                for (int i = 0; i < N; i++)
                    w[i] = int.Parse(reader.ReadLine());

                Array.Sort(w); // 오름 차순 정렬

                int maxWeight = 0; // 물체의 최대 중량을 저장하는 변수
                int count = 1; // 몇번째 로프 인지 확인하는 변수
                for (int i = N - 1; i >= 0; i--)
                {
                    int sum = w[i] * count++; // 현재 선택된 로프 * 총 로프 개수

                    if (sum > maxWeight) // 전 최대 중량이 현재 sum 보다 작으면 max 교체
                        maxWeight = sum;
                }

                writer.WriteLine(maxWeight);

                writer.Close();
                reader.Close();
            }
        }

        public void Q2231()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int sum = 0;

            writer.WriteLine(Result());

            writer.Close();
            reader.Close();

            int Result()
            {
                for (int i = 0; i < N; i++)
                {
                    string s = i.ToString();
                    sum += i;
                    for (int j = 0; j < s.Length; j++)
                        sum += int.Parse(s[j].ToString());

                    if (sum == N)
                        return i;

                    sum = 0;
                }

                return 0;
            }
        }

        public void Q2292()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int room = 1;
            int cnt = 1;

            while (n > room)
            {
                room += 6 * cnt;
                cnt++;
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }

        public void Q2438()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    builder.Append($"*");
                }
                builder.Append("\n");
            }

            Console.WriteLine(builder);
        }

        public void Q2439()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                for (int j = n; j > i; j--)
                    builder.Append($" ");

                for (int j = 0; i > j; j++)
                    builder.Append($"*");

                builder.Append("\n");
            }

            Console.WriteLine(builder);
        }

        public void Q2447()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(ReadLine());
            double m = MathF.Pow(3, 7);
            char[,] map = new char[(int)m, (int)m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                    map[i, j] = ' ';
            }

            Result(n, 0, 0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    writer.Write(map[i, j]);

                writer.WriteLine();
            }

            void Result(int n, int x, int y)
            {
                if (n == 1)
                {
                    map[x, y] = '*';
                    return;
                }

                int div = n / 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 1 && j == 1)
                            continue;

                        Result(div, x + (div * i), y + (div * j));
                    }
                }
                return;
            }

            writer.Close();
            reader.Close();
        }

        public void Q2455()
        {
            // 2455
            // https://www.acmicpc.net/problem/2455
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int result = 0;
            int max = 0;

            for (int i = 0; i < 4; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                result += input[1]; // 탄 사람의 수
                result -= input[0]; // 내린 사람의 수

                if (max < result) // 최대 값 체크
                    max = result;
            }

            writer.WriteLine(max);

            reader.Close();
            writer.Close();
        }

        public void Q2475()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] n = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int sum = 0;
            for (int i = 0; i < n.Length; i++)
                sum += n[i] * n[i];

            writer.WriteLine(sum % 10);

            writer.Close();
            reader.Close();
        }

        public void Q2480()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = data[0];
            int b = data[1];
            int c = data[2];

            if (a == b && b == c)
                Console.WriteLine(10000 + (a * 1000));
            else if (a == b)
                Console.WriteLine(1000 + a * 100);
            else if (a == c)
                Console.WriteLine(1000 + a * 100);
            else if (b == c)
                Console.WriteLine(1000 + b * 100);
            else
                Console.WriteLine(MathF.Max(MathF.Max(a, b), c) * 100);
        }

        public void Q2525()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int h = data[0];
            int m = data[1];

            int needTime = int.Parse(Console.ReadLine());

            m += needTime;

            if (m >= 60)
            {
                h += (m / 60);
                m %= 60;

                if (h >= 24)
                    h -= 24;
            }

            Console.WriteLine($"{h} {m}");
        }
        public void Q2558()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int a = int.Parse(reader.ReadLine());
            int b = int.Parse(reader.ReadLine());

            writer.WriteLine(a + b);

            writer.Close();
            reader.Close();
        }

        public void Q2562()
        {
            List<int> value = new List<int>();

            for (int i = 0; i < 9; i++)
                value.Add(int.Parse(Console.ReadLine()));

            int max = value.Max();
            var result = value.FindIndex(n => n == max);

            Console.WriteLine($"{max}");
            Console.WriteLine($"{result + 1}");
        }

        public void Q2577()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = a * b * c;

            char[] ch = sum.ToString().ToCharArray();
            int[] result = new int[10];

            int length = ch.Length;
            for (int i = 0; i < length; i++)
                result[int.Parse(ch[i].ToString())]++;

            for (int i = 0; i < 10; i++)
                Console.WriteLine(result[i]);
        }

        public void Q2579()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());

            int[] dp = new int[N + 1];
            int[] input = new int[N + 1];

            for (int i = 1; i <= N; i++)
                input[i] = int.Parse(reader.ReadLine());

            dp[1] = input[1];

            // N이 1이 입력될 때 에러가 안나도록 예외처리 추가
            if (N >= 2)
                dp[2] = input[1] + input[2];

            for (int i = 3; i <= N; i++)
            {
                // 각 계단을 밟을때 최댓 값을 찾습니다.
                dp[i] = Math.Max(dp[i - 2], dp[i - 3] + input[i - 1]) + input[i];
            }

            writer.WriteLine(dp[N]);

            writer.Close();
            reader.Close();
        }

        public void Q2581()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int max = 10000 + 1;
            int[] primeNum = new int[max + 1];

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

            int m = int.Parse(reader.ReadLine());
            int n = int.Parse(reader.ReadLine());

            List<int> result = new List<int>();
            int sum = 0;

            for (int i = m; i <= n; i++)
            {
                if (primeNum[i] != 0)
                {
                    result.Add(primeNum[i]);
                    sum += primeNum[i];
                }
            }

            if (sum == 0)
            {
                writer.WriteLine(-1);
            }
            else
            {
                writer.WriteLine(sum);
                writer.WriteLine(result.Min());
            }

            writer.Close();
            reader.Close();
        }

        public void Q2588()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            char[] c = b.ToCharArray();

            int num1 = int.Parse(a);
            int[] num2 = new int[c.Length];

            for (int i = 0; i < c.Length; i++)
            {
                num2[i] = int.Parse(c[i].ToString());
            }

            Console.WriteLine(num1 * num2[2]);
            Console.WriteLine(num1 * num2[1]);
            Console.WriteLine(num1 * num2[0]);
            Console.WriteLine(num1 * int.Parse(b));
        }

        public void Q2606()
        {
            int cnt = 0;
            int[] visited;
            List<int>[] list;
            Queue<int> queue;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int m = int.Parse(reader.ReadLine());

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            queue = new Queue<int>();

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                // 양방향
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            queue.Enqueue(1);
            visited[1] = 1;

            while (queue.Count != 0)
            {
                int q = queue.Dequeue();

                for (int i = 0; i < list[q].Count; i++)
                {
                    int temp = list[q][i];
                    if (visited[temp] != 1)
                    {
                        cnt++;
                        visited[temp] = 1;
                        queue.Enqueue(temp);
                    }
                }
            }

            writer.WriteLine(cnt);
        }

        public void Q2609()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] value = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int gcd, lcd;
            // 최대공약수 ( 유클리트 호제법 )
            gcd = GCD(value[0], value[1]);
            // 최소공배수 ( 두수의 곱 / 최대공약수 )
            lcd = (value[0] * value[1] / gcd);

            writer.WriteLine(gcd);
            writer.WriteLine(lcd);

            writer.Close();
            reader.Close();

            int GCD(int x, int y)
            {
                //두 수 n, m 이 있을 때 어느 한 수가 0이 될 때 까지
                //gcd(m, n%m) 의 재귀함수 반복
                if (y == 0)
                    return x;
                else
                    return GCD(y, x % y);
            }
        }

        public void Q2667()
        {
            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, 1, 0, -1 };

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(Console.ReadLine());
            int[,] arry = new int[n, n];
            int[] result = new int[n * n]; // (n * n / 2) + 1
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();

                for (int j = 0; j < n; j++)
                    arry[i, j] = int.Parse(data[j].ToString());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arry[i, j] == 1)
                    {
                        count++;
                        DFS(i, j, count + 1);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arry[i, j] > 1)
                        result[arry[i, j]]++;
                }
            }

            writer.WriteLine(count);
            Array.Sort(result);
            for (int i = 0; i < result.Length; i++)
                if (result[i] != 0)
                    writer.WriteLine(result[i]);

            void DFS(int x, int y, int count)
            {
                arry[x, y] = count;

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];

                    if ((nx >= 0 && nx < n) && (ny >= 0 && ny < n) && arry[nx, ny] == 1)
                        DFS(nx, ny, count);
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q2675()
        {
            int t = int.Parse(Console.ReadLine());

            for (int n = 0; n < t; n++)
            {
                string[] str = Console.ReadLine().Split();

                int r = int.Parse(str[0]);
                string s = str[1];

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < r; j++)
                        Console.Write(s[i]);
                }

                Console.Write("\n");
            }
        }

        public enum CentType
        {
            Quarter = 0,
            Dime = 1,
            Nickel = 2,
            Penny = 3,

            Max = 4
        }

        public void Q2720()
        {
            // 2720 수학 그리디 알고리즘 사칙연산
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int T = int.Parse(reader.ReadLine());
            int[] money = new int[(int)CentType.Max] { 25, 10, 5, 1 };
            int[] count = new int[(int)CentType.Max];

            for (int i = 0; i < T; i++)
            {
                int USD = int.Parse(reader.ReadLine());

                // 쿼터 개수 반환 + 나머지 반환
                count[(int)CentType.Quarter] = USD / money[(int)CentType.Quarter];
                USD %= money[(int)CentType.Quarter];

                // 다임 개수 반환 + 나머지 반환
                count[(int)CentType.Dime] = USD / money[(int)CentType.Dime];
                USD %= money[(int)CentType.Dime];

                // 페니 개수 반환 + 나머지 반환
                count[(int)CentType.Nickel] = USD / money[(int)CentType.Nickel];
                USD %= money[(int)CentType.Nickel];

                // 나머지 == 페니
                count[(int)CentType.Penny] = USD;

                writer.WriteLine($"{count[(int)CentType.Quarter]} {count[(int)CentType.Dime]} " +
                    $"{count[(int)CentType.Nickel]} {count[(int)CentType.Penny]}");
            }

            writer.Close();
            reader.Close();
        }

        public void Q2739()
        {
            int data = int.Parse(Console.ReadLine());

            for (int i = 1; i < 10; i++)
                Console.WriteLine($"{data} * {i} = {data * i}");
        }

        public void Q2741()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= n; i++)
                builder.Append($"{i}\n");

            Console.WriteLine(builder);
        }

        public void Q2742()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = n; i > 0; i--)
                builder.Append($"{i}\n");

            Console.WriteLine(builder);
        }

        public void Q2747()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[,] fibo = new int[46, 2];

            int n = int.Parse(ReadLine());

            Fibonacci(n);
            WriteLine($"{fibo[n, 1]}");

            (int, int) Fibonacci(int n)
            {
                if (n == 0)
                {
                    fibo[n, 0] = 1;
                    fibo[n, 1] = 0;
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else if (n == 1)
                {
                    fibo[n, 0] = 0;
                    fibo[n, 1] = 1;
                    return (fibo[n, 0], fibo[n, 1]);
                }

                if (fibo[n, 0] != 0 && fibo[n, 1] != 0)
                {
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else
                {
                    fibo[n, 0] = Fibonacci(n - 1).Item1 + Fibonacci(n - 2).Item1;
                    fibo[n, 1] = Fibonacci(n - 1).Item2 + Fibonacci(n - 2).Item2;
                    return (fibo[n, 0], fibo[n, 1]);
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q2748()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            long[,] fibo = new long[91, 2];

            long n = int.Parse(ReadLine());

            Fibonacci(n);
            WriteLine($"{fibo[n, 1]}");

            (long, long) Fibonacci(long n)
            {
                if (n == 0)
                {
                    fibo[n, 0] = 1;
                    fibo[n, 1] = 0;
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else if (n == 1)
                {
                    fibo[n, 0] = 0;
                    fibo[n, 1] = 1;
                    return (fibo[n, 0], fibo[n, 1]);
                }

                if (fibo[n, 0] != 0 && fibo[n, 1] != 0)
                {
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else
                {
                    fibo[n, 0] = Fibonacci(n - 1).Item1 + Fibonacci(n - 2).Item1;
                    fibo[n, 1] = Fibonacci(n - 1).Item2 + Fibonacci(n - 2).Item2;
                    return (fibo[n, 0], fibo[n, 1]);
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q2750()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int[] nArray = new int[n];

            for (int i = 0; i < n; i++)
                nArray[i] = int.Parse(reader.ReadLine());

            Array.Sort(nArray);

            StringBuilder builder = new StringBuilder(string.Join("\n", nArray));
            writer.WriteLine(builder);

            writer.Close();
            reader.Close();
        }

        public void Q2751()
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int[] nArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                nArray[i] = int.Parse(reader.ReadLine());
            }

            Array.Sort(nArray);

            StringBuilder builder = new StringBuilder(string.Join("\n", nArray));
            Console.WriteLine(builder);

            reader.Close();
        }

        public void Q2752()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            Array.Sort(input); // 오름차순으로 정렬

            for (int i = 0; i < input.Length; i++)
                writer.Write(input[i] + " ");

            writer.WriteLine();

            writer.Close();
            reader.Close();
        }

        public void Q2775()
        {
            int t = int.Parse(ReadLine());

            int[,] cnt = new int[15, 15];

            for (int i = 0; i < t; i++)
            {
                int k = int.Parse(ReadLine());
                int n = int.Parse(ReadLine());

                for (int j = 1; j <= k; j++)
                    cnt[j, 1] = 1;

                for (int j = 1; j <= n; j++)
                    cnt[0, j] = j;

                for (int j = 1; j <= k; j++)
                {
                    for (int z = 1; z <= n; z++)
                    {
                        int sum = 0;
                        for (int a = 1; a <= z; a++)
                            sum += cnt[j - 1, a];

                        cnt[j, z] = sum;
                    }
                }

                WriteLine(cnt[k, n]);
            }
        }

        public void Q2753()
        {
            int year = int.Parse(Console.ReadLine());

            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                Console.WriteLine("1");
            else
                Console.WriteLine("0");
        }

        public void Q2805()
        {
            // 2805
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]);  // 나무의 수
            int m = int.Parse(input[1]);  // 상근이가 원하는 나무의 길이

            int[] trees = Array.ConvertAll(reader.ReadLine().Split(), int.Parse); // 나무의 높이

            long start = 0;
            long end = trees.Max();
            long middle = 0;
            long sum = 0;

            // middle과 sum을 담기위한 List
            List<(long, long)> result = new List<(long, long)>();

            while (true)
            {
                sum = 0;

                // start가 end보다 커지는 순간 프로그램 종료
                if (start > end)
                    break;

                // 이분탐색 중간 값
                middle = (start + end) / 2;

                for (int i = 0; i < n; i++)
                {
                    // 잘라낸 나무의 길이 계샨
                    if (trees[i] > middle)
                        sum += trees[i] - middle;
                }

                result.Add((middle, sum));

                // 잘라낸 나무랑 원하는 나무의 길이가 같으면 종료
                if (sum == m)
                    break;

                // 탐색 범위 재설정
                if (sum >= m)
                    start = middle + 1;
                else
                    end = middle - 1;
            }

            // 잘라낸 나무의 총길이로 오름차순정렬
            result.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            foreach (var value in result)
            {
                // 잘라낸 나무의 최대값 
                if (value.Item2 >= m)
                {
                    writer.WriteLine(value.Item1);
                    break;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q2810()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            string seat = reader.ReadLine();

            int count = N + 1; // N개의 연속된 좌석에 양옆 컵홀더가 있으므로 +1 해줍니다. (총 컵홀더 개수)
            int LCount = 0;

            int length = seat.Length;
            for (int i = 0; i < length; i++)
            {
                if (seat[i] == 'L') // 커플석 검사
                    LCount++;
            }

            if (LCount == 0)
                count = N; // 커플석이 하나도 없다면 N개로 초기화
            else
                count -= (LCount / 2); // 커플석 개수만큼 -1

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q2828()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            int J = int.Parse(reader.ReadLine());

            int count = 0;

            int left = 1; // 바구니의 왼쪽 끝 값
            int right = 1 + (M - 1); // 바구니의 오른쪽 끝 값

            for (int i = 0; i < J; i++)
            {
                int apple = int.Parse(reader.ReadLine());

                if (apple > right) // 사과가 오른쪽 끝 값보다 크다면
                {
                    count += apple - right; // 오른쪽 끝 값에서 사과까지 이동해야되는 거리 카운팅
                    right = apple;  // 오른쪽 끝값을 사과가 떨어지는 번호로 이동
                    left = apple - (M - 1); // 왼쪽 끝값은 그만큼 이동
                }
                else if (apple < left) // 사과가 왼쪽 끝값보다 작다면
                {
                    count += left - apple; // 왼쪽 끝 값에서 사과까지 이동해야되는 거리 카운팅
                    left = apple; // 왼쪽 끝값을 사과가 떨어지는 번호로 이동
                    right = apple + (M - 1); // 오른쪽 끝값은 그만큼 이동
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q2839()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int cnt = 0;

            while (n > 0)
            {
                if (n % 5 == 0)
                {
                    n -= 5;
                    cnt++;
                }
                else if (n % 3 == 0)
                {
                    n -= 3;
                    cnt++;
                }
                else if (n > 5)
                {
                    n -= 5;
                    cnt++;
                }
                else
                {
                    cnt = -1;
                    break;
                }
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }

        public void Q2847()
        {
            // 2847 게임을 만든 동준이
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine()); // 총 N개의 레벨
            int[] point = new int[N];
            int count = 0;

            for (int i = 0; i < N; i++)
                point[i] = int.Parse(reader.ReadLine());

            // 레벨이 가장 높은 점수는 변하지 않는다. 
            for (int i = N - 1; i > 0; i--)
            {
                if (point[i] <= point[i - 1]) // 레벨이 낮는데 점수가 크다면
                {
                    int value = (point[i - 1] - point[i]) + 1; // 현재 점수보다 1 낮게 계산
                    count += value; // 1점에 1카운팅 하도록 적용

                    point[i - 1] -= value; // 현재 점수보다 1낮게 반영
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q2864()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();

            (string, string) a = (string.Empty, string.Empty); // min max
            (string, string) b = (string.Empty, string.Empty); // min max

            for (int i = 0; i < input[0].Length; i++)
            {
                a.Item1 += (input[0][i] == '6') ? '5' : input[0][i]; // 6은 5로 변경
                a.Item2 += (input[0][i] == '5') ? '6' : input[0][i]; // 5는 6으로 변경
            }

            for (int i = 0; i < input[1].Length; i++)
            {
                b.Item1 += (input[1][i] == '6') ? '5' : input[1][i];  // 6은 5로 변경
                b.Item2 += (input[1][i] == '5') ? '6' : input[1][i];  // 5는 6으로 변경
            }

            // min + min  max + max
            writer.WriteLine($"{int.Parse(a.Item1) + int.Parse(b.Item1)} {int.Parse(a.Item2) + int.Parse(b.Item2)}");

            writer.Close();
            reader.Close();
        }

        public void Q2869()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            long[] data = Array.ConvertAll(reader.ReadLine().Split(), long.Parse);
            long a = data[0];
            long b = data[1];
            long v = data[2];

            long cnt = 0;

            cnt = (v - b - 1) / (a - b) + 1;

            WriteLine(cnt);

            writer.Close();
            reader.Close();
        }

        public void Q2884()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int h = data[0];
            int m = data[1];

            if (m < 45)
            {
                h--;
                m += 15;

                if (h < 0)
                    h = 23;
            }
            else
            {
                m -= 45;
            }

            Console.WriteLine($"{h} {m}");
        }

        public void Q2908()
        {
            string[] data = Console.ReadLine().Split();

            string a = data[0];
            string b = data[1];

            string ra = a[2].ToString() + a[1] + a[0];
            string rb = b[2].ToString() + b[1] + b[0];

            if (int.Parse(ra) > int.Parse(rb))
                Console.WriteLine(ra);
            else
                Console.WriteLine(rb);
        }

        public void Q2920()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] n = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            List<int> ascending = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> descending = new List<int>() { 8, 7, 6, 5, 4, 3, 2, 1 };

            if (n.ToList().SequenceEqual(ascending))
                writer.WriteLine("ascending");
            else if (n.ToList().SequenceEqual(descending))
                writer.WriteLine("descending");
            else
                writer.WriteLine("mixed");

            writer.Close();
            reader.Close();
        }

        public void Q2941()
        {
            string str = Console.ReadLine();

            string[] croatia = { "c=", "c-", "dz=", "d-", "lj", "nj", "s=", "z=" };

            for (int i = 0; i < croatia.Length; i++)
                str = str.Replace(croatia[i], " ");

            Console.WriteLine(str.Length);
        }

        public void Q2978()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];

            int[] num = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            writer.WriteLine(BlackJack());

            writer.Close();
            reader.Close();

            int BlackJack()
            {
                int max = 0;
                int sum = 0;

                for (int i = 0; i < n - 2; i++)
                {
                    for (int j = i + 1; j < n - 1; j++)
                    {
                        for (int k = j + 1; k < n; k++)
                        {
                            sum = num[i] + num[j] + num[k];

                            if (sum == m)
                                return sum;

                            if (sum > m)
                                continue;

                            if (sum > max)
                                max = sum;
                        }
                    }
                }

                return max;
            }
        }
    }
}
