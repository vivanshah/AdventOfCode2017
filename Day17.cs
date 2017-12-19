using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day17
    {

        static int startIndex = 0;
        public static string Calculate1()

        {
            Console.WriteLine("Day17 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day17.txt");
            var stepCount = int.Parse(lines[0]);
            //ar stepCount = 3;
            List<int> buffer = new List<int>() { 0 };
            int pos = 0;
            int currval = 1;
            for(int x = 0; x < 2017; x++)
            {
                var nextPos = (pos + stepCount) % buffer.Count;
                buffer.Insert(nextPos + 1, currval);
                currval++;
                pos = nextPos +1;
            }

            Console.WriteLine();

            return buffer[buffer.IndexOf(2017) + 1].ToString();
        }



        public static int Calculate2()
        {
            Console.WriteLine("Day17 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day17.txt");
            var stepCount = int.Parse(lines[0]);
            List<int> buffer = new List<int>() { 0 };
            int pos = 0;
            int result = 0;
            for (int x = 0; x < 50000000; x++)
            {
                var nextPos = (pos + stepCount) % (x+1);
                if (nextPos == 0)
                {
                    result = x+1;
                }
                pos = nextPos + 1;
            }
            return result;
        }

    }


}


