﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Question1000
    {
        public void Q1000()
        {
            https://www.acmicpc.net/problem/1000
            string[] data = Console.ReadLine().Split();
            int length = data.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(data[i]);
            }

            Console.WriteLine(sum);
        }

        public void Q1001()
        {
            https://www.acmicpc.net/problem/1001
            string[] data = Console.ReadLine().Split();
            Console.WriteLine(int.Parse(data[0]) - int.Parse(data[1]));
        }

        public void Q1002()
        {
            https://www.acmicpc.net/problem/1002
            // https://mathbang.net/101 참고자료

            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                string[] inputs = Console.ReadLine().Split();

                int x1 = int.Parse(inputs[0]);
                int y1 = int.Parse(inputs[1]);
                int r1 = int.Parse(inputs[2]);
                int x2 = int.Parse(inputs[3]);
                int y2 = int.Parse(inputs[4]);
                int r2 = int.Parse(inputs[5]);

                if (x1 == x2 && y1 == y2 && r1 == r2)
                {
                    // 모든 값이 같을 때 무한대
                    Console.WriteLine(-1);
                    continue;
                }

                double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                int distanceSum = r1 + r2;
                int distanceSub = Math.Abs(r1 - r2);

                if (distanceSub < distance && distance < distanceSum)
                {
                    Console.WriteLine(2);
                }
                else if (distanceSub == distance || distanceSum == distance)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }

        // 피보나치 메모이제이션
        public void Q1003()
        {
            https://www.acmicpc.net/problem/1003
            int[,] fibo = new int[41, 2];

            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Fibonacci(n);
                Console.WriteLine($"{fibo[n, 0]} {fibo[n, 1]}");
            }

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
        }

        public void Q1004 ()
        {
            https://www.acmicpc.net/problem/1004
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int count = 0;
                string[] n = Console.ReadLine().Split();

                (int x1, int y1) = (int.Parse(n[0]), int.Parse(n[1]));
                (int x2, int y2) = (int.Parse(n[2]), int.Parse(n[3]));

                int planetCount = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < planetCount; j++)
                {
                    string[] planetInfo = Console.ReadLine().Split();

                    (int cx, int cy, int r) = (int.Parse(planetInfo[0]), int.Parse(planetInfo[1]), int.Parse(planetInfo[2]));

                    double distance1 = Math.Pow(x1 - cx, 2) + Math.Pow(y1 - cy, 2);
                    double distance2 = Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2);

                    double powR = r * r;

                    // 만약 두 거리가 모두 행성의 반지름 보다 작다면, 출발점과 시작점 모두 행성 내부에 있기 때문에 진입 x
                    // 두 지점 중 하나만 행성 내부에 있는 경우에는 진입 또는 이탈 필요
                    if (powR > distance1 && powR > distance2)
                        continue;
                    else if (powR > distance1)
                        count++;
                    else if (powR > distance2)
                        count++;
                }

                Console.WriteLine(count);
            }
        }

        public void Q1005() 
        {
            https://www.acmicpc.net/problem/1005
            int[] inDegree;
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] str = Console.ReadLine().Split();

                // 건물 갯수 N, 건설 순서 규칙 총 개수 K
                (int n, int k) = (int.Parse(str[0]), int.Parse(str[1]));

                int[] nTime = new int[n + 1];
                int[] resultTime = new int[n + 1];
                string[] str2 = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    nTime[j + 1] = int.Parse(str2[j]); // 걸리는 시간
                    resultTime[j + 1] = int.Parse(str2[j]); // 가중치 줄 시간
                }

                List<int>[] insertEdge = new List<int>[n + 1];

                for (int j = 0; j < n + 1; j++)
                    insertEdge[j] = new List<int>();

                inDegree = new int[n + 1];
                for (int j = 0; j < k; j++)
                {
                    string[] str3 = Console.ReadLine().Split();
                    insertEdge[int.Parse(str3[0])].Add(int.Parse(str3[1])); // 건설 순서
                    inDegree[int.Parse(str3[1])]++; // 진입 갯수
                }

                int w = int.Parse(Console.ReadLine());

                Queue<int> queue = new Queue<int>();

                for (int j = 1; j < n + 1; j++)
                {
                    if (j == w)
                        continue;
                    else if (inDegree[j] == 0)
                        queue.Enqueue(j);
                }

                while (!(queue.Count == 0))
                {
                    int idx = queue.Dequeue();

                    for (int j = 0; j < insertEdge[idx].Count; j++)
                    {
                        int value = insertEdge[idx][j];

                        resultTime[value] = (int)MathF.Max(resultTime[value], resultTime[idx] + nTime[value]); // 가는 방향에 가중치

                        if (--inDegree[value] == 0)
                            queue.Enqueue(value);
                    }
                }

                Console.WriteLine($"{resultTime[w]}");
            }
        }

        public void Q1008()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine((double)A[0] / A[1]);
        }

        public void Q1009()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int result = 1;
                for (int j = 0; j < data[1]; j++)
                    result = (result * data[0]) % 10;

                if (result == 0)
                    result = 10;

                Console.WriteLine($"{result}");
            }
        }

        public void Q1010()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int n = data[0];
                int m = data[1];

                // mCn
                int a = n > (m - n) ? n : (m - n);
                long result = 1;

                for (int j = a + 1; j <= m; j++)
                    result *= j;

                for (int j = 1; j <= (m - a); j++)
                    result /= j;

                Console.WriteLine(result);
            }
        }

        public void Q1012()
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int x = data[0];
                int y = data[1];
                int count = data[2];

                int[,] arry = new int[x, y];
                int[,] visited = new int[x, y];

                for (int j = 0; j < count; j++)
                {
                    string[] str = Console.ReadLine().Split(' ');
                    arry[int.Parse(str[0]), int.Parse(str[1])] = 1;
                }

                Console.WriteLine(BFS(x, y, arry, visited));
            }

            int BFS(int x, int y, int[,] arry, int[,] visited)
            {
                Queue<(int, int)> queue = new Queue<(int, int)>();
                int[] dx = new int[] { 1, 0, -1, 0 };
                int[] dy = new int[] { 0, 1, 0, -1 };

                int result = 0;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (visited[i, j] == 1 || arry[i, j] == 0)
                            continue;

                        queue.Enqueue((i, j));
                        result++;
                        while (queue.Count != 0)
                        {
                            var cur = queue.Dequeue();
                            int curx = cur.Item1;
                            int cury = cur.Item2;

                            for (int dir = 0; dir < 4; dir++)
                            {
                                int nx = cur.Item1 + dx[dir];
                                int ny = cur.Item2 + dy[dir];
                                if (nx < 0 || nx >= x || ny < 0 || ny >= y)
                                    continue;
                                if (visited[nx, ny] == 1 || arry[nx, ny] != 1)
                                    continue;

                                visited[nx, ny] = 1;
                                queue.Enqueue((nx, ny));
                            }
                        }
                    }
                }

                return result;
            }
        }

        public void Q1018()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] value = reader.ReadLine().Split();
            int N = int.Parse(value[0]);
            int M = int.Parse(value[1]);

            char[,] panel = new char[M, N];

            for (int i = 0; i < N; i++)
            {
                string line = reader.ReadLine();

                for (int j = 0; j < M; j++)
                    panel[j, i] = line[j];
            }

            float cnt = 8 * 8;

            for (int i = 0; i <= N - 8; i++)
            {
                for (int j = 0; j <= M - 8; j++)
                {
                    float num = 0;
                    for (int a = i; a < i + 8; a++)
                    {
                        for (int b = j; b < j + 8; b++)
                        {
                            var c = (a + b) % 2 == 0 ? 'W' : 'B';
                            if (c != panel[b, a])
                                num++;
                        }
                    }
                    num = MathF.Min(num, 64 - num);
                    cnt = MathF.Min(cnt, num);
                }
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }

        public void Q1026()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];
            int[] b = new int[n];

            string[] strA = Console.ReadLine().Split();
            string[] strB = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(strA[i]);
                b[i] = int.Parse(strB[i]);
            }

            Array.Sort(a);
            Array.Sort(b, (a, b) => (a > b) ? -1 : 1);

            int sum = 0;

            for (int i = 0; i < n; i++)
                sum += (a[i] * b[i]);

            Console.WriteLine(sum);
        }

        public void Q1032()
        {
            StringBuilder builder = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            string[] name = new string[n];

            string s = string.Empty;

            for (int i = 0; i < n; i++)
                name[i] = Console.ReadLine();

            int length = name[0].Length;
            for (int i = 0; i < length; i++)
            {
                s = string.Empty;
                for (int j = 1; j < n; j++)
                {
                    if (name[0][i] != name[j][i])
                    {
                        s = "?";
                        break;
                    }
                }

                if (s == string.Empty)
                    s = name[0][i].ToString();

                builder.Append(s);
            }

            Console.WriteLine(builder);
        }

        public void Q1037()
        {
            int n = int.Parse(Console.ReadLine());
            int[] number = new int[n];

            number = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(number.Min() * number.Max());
        }

        public void Q1065()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 1; i < n + 1; i++)
            {
                if (FindAP(i))
                    count++;
            }

            Console.WriteLine(count);

            bool FindAP(int num)
            {
                if (num < 100)
                    return true;

                string str = num.ToString();
                int[] numbers = new int[str.Length];

                for (int i = 0; i < str.Length; i++)
                    numbers[i] = int.Parse(str[i].ToString());

                if (numbers[0] - numbers[1] == numbers[1] - numbers[2])
                    return true;

                return false;
            }
        }

        public void Q1075()
        {
            int temp, i;
            int n = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());

            n = (n / 100) * 100;

            for (i = 0; i < 100; i++)
            {
                temp = n;

                if ((temp += i) % f == 0)
                    break;
            }

            if (i < 10)
                Console.Write(0);

            Console.Write(i);
        }

        public void Q1076()
        {
            Dictionary<string, (long, long)> dict = new Dictionary<string, (long, long)>();
            dict.Add("black", (0, 1));
            dict.Add("brown", (1, 10));
            dict.Add("red", (2, 100));
            dict.Add("orange", (3, 1000));
            dict.Add("yellow", (4, 10000));
            dict.Add("green", (5, 100000));
            dict.Add("blue", (6, 1000000));
            dict.Add("violet", (7, 10000000));
            dict.Add("grey", (8, 100000000));
            dict.Add("white", (9, 1000000000));

            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();

            long value = (dict[a].Item1 * 10 + dict[b].Item1) * dict[c].Item2;
            Console.WriteLine(value);
        }

        public void Q1085()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int x = data[0];
            int y = data[1];
            int w = data[2];
            int h = data[3];

            int[] result = new int[4];
            result[0] = x;
            result[1] = y;
            result[2] = w - x;
            result[3] = h - y;

            Console.WriteLine(result.Min());
        }

        public void Q1094()
        {
            int x = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            while (x > 0)
            {
                if (x % 2 == 1)
                    count++;
                x /= 2;
            }

            Console.WriteLine(count);
        }
        public void Q1110()
        {
            string n = Console.ReadLine();
            int added;

            if (10 > int.Parse(n))
                n += 0;

            string originalN = n;

            int count = 0;
            while (true)
            {
                count++;
                int x = int.Parse(n) / 10;
                int y = int.Parse(n) % 10;

                added = x + y;

                n = y.ToString() + (added % 10).ToString();

                if (int.Parse(n) == int.Parse(originalN))
                    break;
            }

            Console.WriteLine(count);
        }
        public void Q1152()
        {
            string[] str = Console.ReadLine().Split();
            int length = str.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == "")
                    count++;
            }
            Console.WriteLine(str.Length - count);
        }

        public void Q1157()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string str = reader.ReadLine().ToUpper();
            int[] counts = new int[26];

            for (int i = 0; i < str.Length; i++)
                counts[str[i] - 'A']++;

            int max = 0;
            int maxIndex = -1;
            bool duplicated = false;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    maxIndex = i;
                    duplicated = false;
                }
                else if (counts[i] == max)
                {
                    duplicated = true;
                }
            }

            writer.WriteLine(duplicated == true ? '?' : (char)(maxIndex + 'A'));

            reader.Close();
            writer.Close();
        }

        public void Q1181()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<string> str = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string s = reader.ReadLine();
                str.Add(s);
            }

            str = str.Distinct().ToList();
            str.Sort();
            List<string> str2 = str.OrderBy(x => x.Length).ToList();

            for (int i = 0; i < str2.Count; i++)
                writer.WriteLine(str2[i]);

            writer.Close();
            reader.Close();
        }

        public void Q1193()
        {
            int n = int.Parse(ReadLine());

            int line = 0;
            int sum = 0;

            while (n > sum)
            {
                line++;
                sum += line;
            }

            int i = n - (sum - line);

            if (line % 2 == 1)
                Write($"{line - i + 1}/{ i}");
            else
                Write($"{i}/{line - i + 1}");
        }

        public void Q1259()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            while (true)
            {
                string n = reader.ReadLine();

                if (n[0] == '0')
                    break;

                writer.WriteLine(Result(n));
            }

            writer.Close();
            reader.Close();

            string Result(string n)
            {
                for (int i = 0, j = n.Length - 1; i < n.Length; i++, j--)
                {
                    if (int.Parse(n[i].ToString()) != int.Parse(n[j].ToString()))
                        return "no";
                }

                return "yes";
            }
        }

        public void Q1260()
        {
            int[] visited;
            List<int>[] list;
            Queue<int> queue;
            List<int> result;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[1001];
            visited = new int[1001];
            result = new List<int>();

            for (int i = 0; i < 1001; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                // 양방향
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < 1001; i++)
                list[i].Sort();

            DFS(r);

            for (int i = 0; i < result.Count; i++)
                writer.Write(result[i] + " ");

            void DFS(int start)
            {
                if (visited[start] == 1)
                    return;

                visited[start] = 1;
                result.Add(start);

                for (int i = 0; i < list[start].Count; i++)
                    DFS(list[start][i]);
            }

            // ---------------------------------------------------------------------------------------

            queue = new Queue<int>();
            visited = new int[1001];
            result.Clear();

            queue.Enqueue(r);
            result.Add(r);
            visited[r] = 1;

            while (queue.Count != 0)
            {
                int q = queue.Dequeue();

                for (int i = 0; i < list[q].Count; i++)
                {
                    int temp = list[q][i];
                    if (visited[temp] != 1)
                    {
                        visited[temp] = 1;
                        result.Add(temp);
                        queue.Enqueue(temp);
                    }
                }
            }

            writer.Write("\n");

            for (int i = 0; i < result.Count; i++)
                writer.Write(result[i] + " ");

            writer.Close();
            reader.Close();
        }

        public void Q1316()
        {
            int n = int.Parse(Console.ReadLine());
            int cnt = 0;

            for (int i = 0; i < n; i++)
            {
                if (Word(Console.ReadLine()))
                    cnt++;
            }

            Console.WriteLine(cnt);

            bool Word(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (j - i > 1 && s[i] == s[j])
                            return false;
                        if (s[i] == s[j])
                            i += j - i;
                    }
                }

                return true;
            }
        }

        public void Q1330()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            if (data[0] == data[1])
                Console.WriteLine("==");
            else if (data[0] > data[1])
                Console.WriteLine(">");
            else
                Console.WriteLine("<");
        }

        public void Q1436()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int cnt = 0;
            int start = 666;

            while (true)
            {
                // 영화 제목에 666이 포함되면 cnt를 증가
                if (start.ToString().Contains("666"))
                    cnt++;

                // 입력 받은 값이랑 같으면 반복문 중단
                if (n == cnt)
                    break;

                start++;
            }

            writer.Write($"{start}");

            writer.Close();
            reader.Close();
        }

        public void Q1546()
        {
            int n = int.Parse(Console.ReadLine());

            int[] grade = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            float max = grade.ToList().Max();

            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += grade[i] / max * 100;
            }

            Console.WriteLine((float)sum / n);
        }

        public void Q1697()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int k = data[1];
            bool[] visited = new bool[100001];

            Queue<(int, int)> queue = new Queue<(int, int)>();

            queue.Enqueue((n, 0));
            int result = 0;

            while (queue.Count != 0)
            {
                var q = queue.Dequeue();

                if (q.Item1 < 0 || q.Item1 > 100000)
                    continue;
                if (visited[q.Item1])
                    continue;

                visited[q.Item1] = true;

                if (q.Item1 == k)
                    result = q.Item2;

                queue.Enqueue((q.Item1 * 2, q.Item2 + 1));
                queue.Enqueue((q.Item1 + 1, q.Item2 + 1));
                queue.Enqueue((q.Item1 - 1, q.Item2 + 1));
            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1712()
        {
            int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = value[0];
            int b = value[1];
            int c = value[2];

            if (b >= c)
            {
                Console.WriteLine(-1);
                return;
            }

            // a+bn = cn
            // a = cn - bn
            // a = n(c-b)
            // a / (c-b) = n
            Console.WriteLine((a / (c - b)) + 1);
        }

        public void Q1920()
        {
            // 기본 List 서치방식
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] result = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int print = 0;
            for (int i = 0; i < m; i++)
            {
                print = (a.Contains(result[i])) ? 1 : 0;
                writer.WriteLine(print);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1920_2()
        {
            // 이진탐색
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] b = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            a.Sort();
            int[] result = new int[b.Length];

            for (int i = 0; i < m; i++)
            {
                int start = 0;
                int end = a.Count - 1;
                int middle = 0;

                while (true)
                {
                    middle = (start + end) / 2;
                    if (middle == start)
                    {
                        if (a[start] == b[i] || a[end] == b[i])
                            result[i] = 1;
                        else
                            result[i] = 0;
                        break;
                    }
                    else if (a[middle] == b[i])
                    {
                        result[i] = 1;
                        break;
                    }
                    else if (a[middle] > b[i])
                    {
                        end = middle;
                    }
                    else if (a[middle] < b[i])
                    {
                        start = middle;
                    }
                }
            }

            StringBuilder sb = new StringBuilder(string.Join("\n", result));

            writer.WriteLine(sb);

            writer.Close();
            reader.Close();
        }

        public void Q1920_3()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] b = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            a.Sort();
            int[] result = new int[b.Length];

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < m; i++)
            {
                int start = 0;
                int end = a.Count - 1;
                bool found = false;

                while (start <= end && !found)
                {
                    int middle = (start + end) / 2;

                    if (a[middle] == b[i])
                        found = true;
                    else if (a[middle] > b[i])
                        end = middle - 1;
                    else
                        start = middle + 1;
                }
                sb.Append(found ? "1\n" : "0\n");
            }

            writer.WriteLine(sb);

            writer.Close();
            reader.Close();
        }

        public void Q1929()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = Eratosthenes(1000000 + 1);

            string[] str = reader.ReadLine().Split();
            int m = int.Parse(str[0]);
            int n = int.Parse(str[1]);

            for (int i = m; i <= n; i++)
            {
                if (primeNum[i] != 0)
                    writer.WriteLine(primeNum[i]);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1978()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = new int[1001];

            for (int i = 2; i <= 1000; i++)
                primeNum[i] = i;

            float num = MathF.Sqrt(1000);
            for (int i = 2; i <= num; i++)
            {
                if (primeNum[i] == 0)
                    continue;

                for (int j = i * i; j <= 1000; j += i)
                    primeNum[j] = 0;
            }


            int n = int.Parse(reader.ReadLine());

            int[] value = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int cnt = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (primeNum[value[i]] != 0)
                    cnt++;
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }
    }
}
