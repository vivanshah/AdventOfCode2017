using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day5
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day5 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day5.txt");
            var ins = lines.Select(x => int.Parse(x)).ToArray();
            int ptr = 0;
            int count = 0;
            int next = 0;
            while(ptr >= 0 && ptr < ins.Length)
            {
                next = ins[ptr];
                ins[ptr]++;
                ptr +=next;
                count++;
            }
            Console.WriteLine(count);
            return count.ToString();
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day5 part 2");
            var sw = new Stopwatch();
            sw.Start();
            var lines = File.ReadAllLines("..\\..\\Input\\Day5.txt");
            var ins = lines.Select(x => int.Parse(x)).ToArray();
            int ptr = 0;
            int count = 0;
            int next = 0;
            while (ptr >= 0 && ptr < ins.Length)
            {
                next = ins[ptr];
                ins[ptr] += next > 2 ? -1 : 1;
                ptr += next;
                count++;
            }
            sw.Stop();
            Console.WriteLine(count + " in " + sw.ElapsedMilliseconds + " ms");
            return count.ToString();
        }

    }
}
