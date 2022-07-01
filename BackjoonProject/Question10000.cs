using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

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

        public void Q10773()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int k = int.Parse(reader.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < k; i++)
            {
                int num = int.Parse(reader.ReadLine());
                if (num == 0)
                    stack.Pop();
                else
                    stack.Push(num);
            }

            writer.WriteLine(stack.Sum());

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

        public void Q10828()
        {
            // List로 Stack 구현
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<int> stack = new List<int>();

            int n = int.Parse(reader.ReadLine());

            string[] push = new string[2];
            string str;
            for (int i = 0; i < n; i++)
            {
                str = reader.ReadLine();

                if (str.Contains("push"))
                    push = str.Split();

                switch (str)
                {
                    case "top":
                        if (stack.Count > 0)
                            writer.WriteLine(stack.Last());
                        else
                            writer.WriteLine(-1);
                        break;
                    case "pop":
                        if (stack.Count > 0)
                        {
                            writer.WriteLine(stack.Last());
                            stack.RemoveAt(stack.Count - 1);
                        }
                        else
                        {
                            writer.WriteLine(-1);
                        }
                        break;
                    case "size":
                        writer.WriteLine(stack.Count);
                        break;
                    case "empty":
                        writer.WriteLine((stack.Count == 0) ? 1 : 0);
                        break;
                    default:
                        stack.Add(int.Parse(push[1].ToString()));
                        break;
                }
            }


            writer.Close();
            reader.Close();
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

        public void Q10870()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int result = 0;
            result += Fibonacci(n);

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
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

        public void Q10872()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(ReadLine());
            int sum = 1;
            Factorial(n);

            writer.WriteLine(sum);

            writer.Close();
            reader.Close();

            int Factorial(int n)
            {

                if (n == 0)
                    return 0;

                sum *= n;

                return Factorial(n - 1);
            }
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

        public void Q11729()
        {
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int cnt = 0;

            Recursion(n, 1, 2, 3);

            writer.WriteLine(cnt);

            writer.WriteLine(builder);

            reader.Close();
            writer.Close();

            void Recursion(int n, int from, int mid, int to)
            {
                if (n == 1)
                {
                    builder.AppendLine($"{from} {to}");
                    cnt++;
                }
                else
                {
                    Recursion(n - 1, from, to, mid);

                    builder.AppendLine($"{from} {to}");
                    cnt++;

                    Recursion(n - 1, mid, from, to);
                }
            }
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

        public void Q17478()
        {
            // 문제를 틀렸습니다. ( 나중에 문제 해결 할예정 )
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int max = n;

            writer.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
            Recursion(n);

            reader.Close();
            writer.Close();

            void Recursion(int n)
            {
                if (n == 0)
                {
                    writer.WriteLine(builder + "\"재귀함수가 뭔가요 ? \"");
                    writer.WriteLine(builder + "\"재귀함수는 자기 자신을 호출하는 함수라네\"");

                    for (int i = 1; i <= max; i++)
                    {
                        writer.WriteLine(builder + "라고 답변하였지.");

                        builder.Remove((max * 4) - (i * 4), 4);
                    }
                    writer.WriteLine("라고 답변하였지.");
                    return;
                }

                writer.WriteLine(builder + "\"재귀함수가 뭔가요 ? \"");
                writer.WriteLine(builder + "\"잘 들어보게.옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
                writer.WriteLine(builder + "마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
                writer.WriteLine(builder + "그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");
                builder.Append("____");

                Recursion(n - 1);
            }
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
