using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question5000
    {
        public void Q5622()
        {
            string str = Console.ReadLine();
            int cnt = 0;

            for (int i = 0; i < str.Length; i++)
                cnt += FindNumber(str[i]);

            Console.WriteLine(cnt);

            int FindNumber(int a) =>
                a switch
                {
                    int b when b < 68 => 3,
                    int b when b < 71 => 4,
                    int b when b < 74 => 5,
                    int b when b < 77 => 6,
                    int b when b < 80 => 7,
                    int b when b < 84 => 8,
                    int b when b < 87 => 9,
                    _ => 10,
                };
        }
    }
}
