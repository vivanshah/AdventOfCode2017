using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day1
    {
        public static string Calculate1()
        {
            var lines = File.ReadAllLines("..\\..\\Input\\Day1.txt");
            var digits = lines[0];
            //var digits = "1122";
            var sum = 0;
            int x = 0;
            for(; x < digits.Length; x++)
            {
                if(digits[x] == digits[(x + 1) % digits.Length])
                {
                    sum +=Convert.ToInt32("" + digits[x]);
                }
            }

            Console.WriteLine(sum);
            return sum.ToString();
        }

        public static string Calculate2()
        {
            var lines = File.ReadAllLines("..\\..\\Input\\Day1.txt");
            var digits = lines[0];
            //var digits = "123425";
            var sum = 0;
            int x = 0;
            for (; x < digits.Length; x++)
            {
                if (digits[x] == digits[(x + (digits.Length /2)) % digits.Length])
                {
                    sum += Convert.ToInt32("" + digits[x]);
                }
            }

            Console.WriteLine(sum);
            return sum.ToString();

        }
    }
}
