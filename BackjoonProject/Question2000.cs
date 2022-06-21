using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackjoonProject
{
    class Question2000
    {
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

        public void Q2571()
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

        public void Q2753()
        {
            int year = int.Parse(Console.ReadLine());

            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                Console.WriteLine("1");
            else
                Console.WriteLine("0");
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
    }
}
