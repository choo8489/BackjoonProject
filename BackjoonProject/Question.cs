using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question
    {
        public void Q1000()
        {
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
            string[] data = Console.ReadLine().Split();
            Console.WriteLine(int.Parse(data[0]) - int.Parse(data[1]));
        }

        public void Q1002()
        {
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
    }
}
