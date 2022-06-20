﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
