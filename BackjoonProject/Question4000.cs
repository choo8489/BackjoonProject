using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question4000
    {
        public void Q4344()
        {
            int c = int.Parse(Console.ReadLine());

            for (int i = 0; i < c; i++)
            {
                int[] grade = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                int sum = 0;
                for (int j = 1; j < grade[0] + 1; j++)
                    sum += grade[j];

                float avg = (float)sum / grade[0];

                int count = 0;
                for (int j = 1; j < grade[0] + 1; j++)
                {
                    if ((float)grade[j] > avg)
                        count++;
                }

                float result = count / (float)grade[0] * 100;

                Console.WriteLine($"{MathF.Round(result, 3):0.000}%");
            }
        }
    }
}
