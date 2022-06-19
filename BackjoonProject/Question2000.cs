using System;
using System.Collections.Generic;
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
