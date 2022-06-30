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
