using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day11
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day11 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day11.txt");
            var input = lines[0];
            //var input = "ne,ne,s,s";
            int x=0, y=0;
            int distance = 0;
            int maxDistance = 0;
            var steps = input.Split(',');
            foreach(var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y++;
                        break;
                    case "s":
                        y--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    case "ne":
                        x++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "sw":
                        x--;
                        break;

                }
                distance = (Math.Abs(x) + Math.Abs(y) + Math.Abs(x + y)) / 2;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
            

            return maxDistance.ToString();
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day11 part 2");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day11.txt");
            var line = lines[0];

            //result = (array[0] * array[1]).ToString();
            return result;
        }

        
    }
}

