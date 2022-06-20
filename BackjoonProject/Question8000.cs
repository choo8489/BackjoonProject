using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question8000
    {
        public void Q8393()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= n; i++)
                sum += i;

            Console.WriteLine(sum);
        }

        public void Q8958()
        {
            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                string str = Console.ReadLine();

                char[] ox = str.ToCharArray();
                int length = ox.Length;

                int sum = 0;
                int count = 0;
                for (int i = 0; i < length; i++)
                {
                    if (ox[i] == 'O')
                        sum += 1 + count;

                    if (ox[i] == 'O')
                        count++;
                    else
                        count = 0;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
