using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day9
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day9 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day9.txt");

            int groupCount = 0, score = 0, garbageCount = 0;
            var input = lines[0];
            bool inGarbage = false;
            for(int x = 0;x<input.Length;x++)
            {
                char c = input[x];
                if(c == '<' && !inGarbage)
                {
                    inGarbage = true;
                    continue;
                }
                if (inGarbage)
                {
                    if(c == '!')
                    {
                        x++;
                        continue;
                    }
                    if(c == '>')
                    {
                        inGarbage = false;
                        continue;
                    }
                    garbageCount++;
                }
                else
                {
                    if (c == '{')
                    {
                        groupCount++;
                    }
                    else if (c == '}')
                    {
                        score += groupCount;
                        groupCount--;
                    }
                }
            }
            result = "Part 1: " + score + "\r\nPart2: " + garbageCount;
            return result;
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day9 part 2");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day9.txt");

            //result = 
            return result;
        }
    }
}
