using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static System.Console;

namespace BackjoonProject
{
    class Question10000
    {
        public void Q10172()
        {
            Console.WriteLine("|\\_/|");
            Console.WriteLine("|q p|   /}");
            Console.WriteLine("( 0 )\"\"\"\\");
            Console.WriteLine("|\"^\"`    |");
            Console.WriteLine("||_/=\\\\__|");
        }

        public void Q10250()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int t = int.Parse(reader.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                int h = data[0];
                int w = data[1];
                int n = data[2];

                int cnt = 0;

                for (int j = 1; j <= w; j++)
                {
                    for (int z = 1; z <= h; z++)
                    {
                        cnt++;

                        if (n == cnt)
                        {
                            writer.WriteLine($"{z}{j:00}");
                            break;
                        }
                    }

                    if (n == cnt)
                        break;
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q10434()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine((data[0] + data[1]) % data[2]);
            Console.WriteLine(((data[0] % data[2]) + (data[1] % data[2])) % data[2]);
            Console.WriteLine((data[0] * data[1]) % data[2]);
            Console.WriteLine(((data[0] % data[2]) * (data[1] % data[2])) % data[2]);
        }

        public void Q10757()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] str = reader.ReadLine().Split();

            float max = MathF.Max(str[0].Length, str[1].Length);

            int[] a = new int[(int)max + 1];
            int[] b = new int[(int)max + 1];

            for (int i = str[0].Length - 1, j = 0; i >= 0; i--, j++)
                a[j] = int.Parse(str[0][i].ToString());

            for (int i = str[1].Length - 1, j = 0; i >= 0; i--, j++)
                b[j] = int.Parse(str[1][i].ToString());

            for (int i = 0; i < (int)max; i++)
            {
                int value = a[i] + b[i];
                a[i] = value % 10;
                a[i + 1] += (value / 10);
            }

            if (a[(int)max] != 0)
                writer.Write(a[(int)max]);

            for (int i = (int)max - 1; i >= 0; i--)
                writer.Write(a[i]);

            writer.Close();
            reader.Close();
        }

        public void Q10818()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            using (StringReader reader = new StringReader(Console.ReadLine()))
            {
                List<int> text = (Array.ConvertAll(reader.ReadLine().Split(), int.Parse)).ToList();

                builder.Append($"{text.Min()} {text.Max()}");
            }

            Console.WriteLine(builder);
        }

        public void Q10869()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(A[0] + A[1]);
            Console.WriteLine(A[0] - A[1]);
            Console.WriteLine(A[0] * A[1]);
            Console.WriteLine(A[0] / A[1]);
            Console.WriteLine(A[0] % A[1]);
        }

        public void Q10871()
        {
            StringBuilder builder = new StringBuilder();

            int[] text = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int i = 0; i < text[0]; i++)
            {
                if (text[1] > value[i])
                    builder.Append($"{value[i]} ");
            }
            builder.Append("\n");

            Console.WriteLine(builder);
        }

        public void Q10926()
        {
            string id = Console.ReadLine();
            Console.WriteLine($"{id}??!");
        }

        public void Q10950()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                Console.WriteLine(data[0] + data[1]);
            }
        }

        public void Q10951()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == null)
                    break;

                int[] text = Array.ConvertAll(input.Split(), int.Parse);
                Console.WriteLine(text[0] + text[1]);
            }
        }

        public void Q10952()
        {
            while (true)
            {
                string input = Console.ReadLine();

                int[] text = Array.ConvertAll(input.Split(), int.Parse);

                if (text[0] == 0 && text[1] == 0)
                    break;

                Console.WriteLine(text[0] + text[1]);
            }
        }

        public void Q10989()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int[] nArray = new int[10001];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(reader.ReadLine());
                nArray[num]++;
            }

            for (int i = 0; i < 10001; i++)
                for (int j = 0; j < nArray[i]; j++)
                    writer.WriteLine(i);

            writer.Close();
            reader.Close();
        }

        public void Q10998()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(A[0] * A[1]);
        }

        public void Q11021()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"Case #{i + 1}: {text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q11022()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"Case #{i + 1}: {text[0]} + {text[1]} = {text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q11653()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> result = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    result.Add(i);
                    n /= i;
                }
            }

            int count = result.Count;

            for (int i = 0; i < count; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();
        }

        public void Q11654()
        {
            string str = Console.ReadLine();

            Console.WriteLine((int)str[0]);
        }

        public void Q11720()
        {
            int n = int.Parse(Console.ReadLine());

            char[] c = Console.ReadLine().ToCharArray();

            int length = c.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(c[i].ToString());
            }

            Console.WriteLine(sum);
        }

        public void Q14681()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
                Console.WriteLine(1);
            else if (x < 0 && y > 0)
                Console.WriteLine(2);
            else if (x < 0 && y < 0)
                Console.WriteLine(3);
            else
                Console.WriteLine(4);
        }

        public void Q15552()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                using (StringReader reader = new StringReader(Console.ReadLine()))
                {
                    int[] text = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                    builder.Append($"{text[0] + text[1]}\n");
                }
            }

            Console.WriteLine(builder);
        }

        public void Q18108()
        {
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine($"{y - 543}");
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
