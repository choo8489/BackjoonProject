using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question3000
    {
        public void Q3052()
        {
            int[] n = new int[43];
            for (int i = 0; i < 10; i++)
                n[int.Parse(Console.ReadLine()) % 42]++;

            int count = 0;
            for (int i = 0; i < 43; i++)
            {
                if (n[i] > 0)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
