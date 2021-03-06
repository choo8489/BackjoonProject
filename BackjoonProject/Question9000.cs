using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Question9000
    {
        public void Q9012()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int T = int.Parse(reader.ReadLine());
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < T; i++)
                writer.WriteLine(FindVPS());

            writer.Close();
            reader.Close();

            string FindVPS()
            {
                stack.Clear();
                string str = reader.ReadLine();

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '(')
                        stack.Push(str[j]);
                    else
                    {
                        if (stack.TryPop(out char value))
                        {
                            if (value == ')')
                                return "NO";
                        }
                        else
                            return "NO";

                    }
                }

                if (stack.Count > 0)
                    return "NO";

                return "YES";
            }
        }

        public void Q9020()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = Eratosthenes(10000 + 1);

            int t = int.Parse(reader.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(reader.ReadLine());
                int a = n / 2;
                int b = n / 2;

                while (true)
                {
                    if (primeNum[a] != 0 && primeNum[b] != 0)
                    {
                        writer.WriteLine($"{primeNum[a]} {primeNum[b]}");
                        break;
                    }

                    a--;
                    b++;
                }
            }

            writer.Close();
            reader.Close();
        }

        private Stream OpenStandardInput()
        {
            throw new NotImplementedException();
        }

        private Stream OpenStandardOutput()
        {
            throw new NotImplementedException();
        }

        public void Q9498()
        {
            int grade = int.Parse(Console.ReadLine());

            if (90 <= grade && grade <= 100)
                Console.WriteLine("A");
            else if (80 <= grade && grade <= 89)
                Console.WriteLine("B");
            else if (70 <= grade && grade <= 79)
                Console.WriteLine("C");
            else if (60 <= grade && grade <= 69)
                Console.WriteLine("D");
            else
                Console.WriteLine("F");
        }
    }
}
