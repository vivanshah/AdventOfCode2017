using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day6
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day6 part 1");
            string result = null;
            HashSet<string> prev = new HashSet<string>();
            var lines = File.ReadAllLines("..\\..\\Input\\Day6.txt");
            var blocks = lines[0].Split('\t').Select(x => Int32.Parse(x)).ToList();
            // blocks = new List<int> { 0, 2, 7, 0 };
            
            int count = 0;
            while (!prev.Contains(string.Concat(blocks)))
            {
                prev.Add(string.Concat(blocks));
                Rebalance(blocks);
                count++;
            }
            Console.WriteLine(count);
            result = count.ToString();
            return result;
        }
        public static void Rebalance (List<int> blocks)
        {
            int maxindex = 0;
            int max = Int32.MinValue;
            for(int x = 0; x < blocks.Count; x++)
            {
                if (blocks[x] > max)
                {
                    maxindex = x;
                    max = blocks[x];
                }
            }

            var dist = blocks[maxindex];
            blocks[maxindex] = 0;
            while(dist > 0)
            {
                maxindex = (maxindex + 1) % blocks.Count;
                blocks[maxindex]++;
                dist--;
            }

        }

        public static string Calculate2()
        {
            Console.WriteLine("Day6 part 1");
            HashSet<string> prev = new HashSet<string>();
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day6.txt");
            var blocks = lines[0].Split('\t').Select(x => Int32.Parse(x)).ToList();
            // blocks = new List<int> { 0, 2, 7, 0 };
            prev.Add(string.Concat(blocks));
            int count = 0;
            string loopstate = null;
            while (true)
            {
                Rebalance(blocks);
                count++;
                if (prev.Contains(string.Concat(blocks)))
                {
                    if (loopstate == null)
                    {
                        count = 0;
                        prev.Clear();
                        loopstate = string.Concat(blocks);
                    } else
                    {
                        break;
                    }
                }
                prev.Add(String.Concat(blocks));
            }
            Console.WriteLine(count);
            result = count.ToString();
            return result;
        }

    }
}
