using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day15
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day15 part 1");
            //var lines = File.ReadAllLines("..\\..\\Input\\Day15.txt");
            long a = 591;
            long b = 393;
            long afactor = 16807;
            long bfactor = 48271;
            int match = 0;
            for(int x = 0; x < 40000001; x++)
            {
                a = (a * afactor) % 2147483647;
                b = (b * bfactor) % 2147483647;
                long xor = a ^ b ;
                long and = xor & 0b00000000000000001111111111111111;

                if (and == 0)
                {
                    match++;
                }

            }
            return match.ToString();
        }



        public static string Calculate2()
        {
            Console.WriteLine("Day15 part 2");
            //var lines = File.ReadAllLines("..\\..\\Input\\Day15.txt");
            long a = 591;
            long b = 393;
            long afactor = 16807;
            long bfactor = 48271;
            int match = 0;
            List<long> alist = new List<long>();
            List<long> blist = new List<long>();
            for (long x = 0; x < long.MaxValue; x++)
            {
                a = (a * afactor) % 2147483647;
                b = (b * bfactor) % 2147483647;
                if(a%4 == 0)
                {
                    alist.Add(a);
                }
                if (b % 8 == 0)
                {
                    blist.Add(b);
                }
                if(alist.Count > 5000000 && blist.Count > 5000000)
                {
                    break;
                }

            }

            for(int x = 0; x < Math.Min(alist.Count, blist.Count); x++)
            {
                long xor = alist[x] ^ blist[x];
                long and = xor & 0b00000000000000001111111111111111;

                if (and == 0)
                {
                    match++;
                }

            }
            return match.ToString();
        }

    }


}


