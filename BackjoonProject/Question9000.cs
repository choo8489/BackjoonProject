using System;
using System.Collections.Generic;
using System.Text;

namespace BackjoonProject
{
    class Question9000
    {
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
