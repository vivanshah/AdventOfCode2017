using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day2
    {
        public static void Calculate1()
        {
            Console.WriteLine("Day2 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day2.txt");
            int checksum = 0;
            foreach(var c in lines)
            {
                var values = c.Split('\t').Select(x => Convert.ToInt32(x));
                var diff = Math.Abs(Enumerable.Max(values) - Enumerable.Min(values));
                checksum += diff;
            }
            Console.WriteLine(checksum);
        }

        public static void Calculate2()
        {
            Console.WriteLine("Day2 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day2.txt");
            int checksum = 0;
            foreach (var c in lines) {
                var values = c.Split('\t').Select(x => Convert.ToInt32(x));
                foreach (var v in values) {
                    foreach(var z in values) {
                        if(z == v) {
                            continue;
                        }
                        if(z > v) {
                            if(z % v == 0) {
                                checksum += z / v;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(checksum);
        }
    }
}
