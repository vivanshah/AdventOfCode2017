using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day4
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day4 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day4.txt");
            var count = 0;
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                if(words.Distinct().Count() == words.Count())
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            return count.ToString();
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day4 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day4.txt");
            var count = 0;
            foreach (var line in lines)
            {
                var words = line.Split(' ').Select(x=>new String(x.OrderBy(c=>c).ToArray()));
                
                if (words.Distinct().Count() == words.Count())
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            return count.ToString();
        }

    }
}
