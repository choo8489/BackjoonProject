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
    }
}
