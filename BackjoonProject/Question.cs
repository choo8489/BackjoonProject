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
    }
}
