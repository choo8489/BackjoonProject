using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    class Question20000
    {
        public void Q24416()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());

            int count = 0;
            int count2 = 0;

            Fib(N, ref count);
            Fibonacci(N, ref count2);

            writer.WriteLine($"{count} {count2}");

            writer.Close();
            reader.Close();

            // 재귀호출
            int Fib(int n, ref int count)
            {
                if (n == 1 || n == 2)
                {
                    count++; // 코드1 카운팅
                    return 1;
                }
                else
                {
                    return Fib(n - 1, ref count) + Fib(n - 2, ref count);
                }
            }

            // 동적프로그래밍 
            int Fibonacci(int n, ref int count)
            {
                int[] f = new int[n + 1];

                f[1] = 1;
                f[2] = 1;

                for (int i = 3; i <= n; i++)
                {
                    f[i] = f[i - 1] + f[i - 2];
                    // 코드2 카운팅
                    count++;
                }

                return f[n];
            }
        }
        public void Q24444()
        {
            int cnt = 0;
            int[] visited;
            int[] result;
            List<int>[] list;
            Queue<int> queue;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            result = new int[n + 1];
            queue = new Queue<int>();

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < n + 1; i++)
                list[i].Sort();

            queue.Enqueue(r);
            visited[r] = 1;
            cnt++;
            result[r] = cnt;

            while (queue.Count != 0)
            {
                int q = queue.Dequeue();

                for (int i = 0; i < list[q].Count; i++)
                {
                    int temp = list[q][i];
                    if (visited[temp] != 1)
                    {
                        cnt++;
                        result[temp] = cnt;
                        visited[temp] = 1;
                        queue.Enqueue(temp);
                    }
                }
            }

            for (int i = 1; i < result.Length; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();
        }

        public void Q24445()
        {
            int cnt = 0;
            int[] visited;
            int[] result;
            List<int>[] list;
            Queue<int> queue;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            result = new int[n + 1];
            queue = new Queue<int>();

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < n + 1; i++)
            {
                list[i].Sort();
                list[i].Reverse();
            }

            queue.Enqueue(r);
            visited[r] = 1;
            cnt++;
            result[r] = cnt;

            while (queue.Count != 0)
            {
                int q = queue.Dequeue();

                for (int i = 0; i < list[q].Count; i++)
                {
                    int temp = list[q][i];
                    if (visited[temp] != 1)
                    {
                        cnt++;
                        result[temp] = cnt;
                        visited[temp] = 1;
                        queue.Enqueue(temp);
                    }
                }
            }

            for (int i = 1; i < result.Length; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();
        }

        public void Q24479()
        {
            int cnt = 0;
            int[] visited;
            int[] result;
            List<int>[] list;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            result = new int[n + 1];

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < n + 1; i++)
                list[i].Sort();

            DFS(r);

            for (int i = 1; i <= n; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();

            void DFS(int r)
            {
                if (visited[r] == 1)
                    return;

                visited[r] = 1;
                cnt++;
                result[r] = cnt;

                for (int i = 0; i < list[r].Count; i++)
                    DFS(list[r][i]);
            }
        }

        public void Q24480()
        {
            int cnt = 0;
            int[] visited;
            int[] result;
            List<int>[] list;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            result = new int[n + 1];

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < n + 1; i++)
            {
                list[i].Sort();
                list[i].Reverse();
            }

            DFS(r);

            for (int i = 1; i <= n; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();

            void DFS(int r)
            {
                if (visited[r] == 1)
                    return;

                visited[r] = 1;
                cnt++;
                result[r] = cnt;

                for (int i = 0; i < list[r].Count; i++)
                    DFS(list[r][i]);
            }
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
