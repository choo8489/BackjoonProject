using System;
using System.Collections.Generic;
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
    }
}
