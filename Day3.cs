using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day3
    {
        public static void Calculate1()
        {
            //solved pen & paper and then backported spiral generation from part 2 later on :S
            Console.WriteLine("Day3 part 1");
            var input = 361527;

            int[,] big = new int[10000, 10000];


            int x = 10000 / 2;
            int y = 10000 / 2;
            big[x, y] = 1;
            int h = 1;
            int count = 2;
            int v = 1;
            while (count <= input)
            {
                for (int i = 0; i < h && count <= input; i++)
                {
                    y++;
                    big[x, y] = count;
                    count++;
                }
                h++;
                for (int i = 0; i < v && count <= input; i++)
                {
                    x--;
                    big[x, y] = count;
                    count++;
                }
                v++;
                for (int i = 0; i < h && count <= input; i++)
                {
                    y--;
                    big[x, y] = count;
                    count++;
                }
                h++;
                for (int i = 0; i < v && count <= input; i++)
                {
                    x++;
                    big[x, y] = count;
                    count++;
                }
                v++;
            }

            Console.WriteLine((Math.Abs((10000/2) - x)) + Math.Abs((10000/2) - y));
        }

        public static void Calculate2()
        {
            Console.WriteLine("Day3 part 2");
            var input = 361527;

            int[,] big = new int[10000, 10000];


            int x = 10000 / 2;
            int y = 10000 / 2;
            big[x, y] = 1;
            int h= 1;
            int sum = 0;
            int v = 1;
            while (sum <= input)
            {
                for (int i = 0; i < h && sum <= input; i++)
                {
                    y++;
                    big[x, y] = sum = GetSum(big, x, y);
                }
                h++;
                for (int i = 0; i < v && sum <= input; i++)
                {
                    x--;
                    big[x, y] = sum = GetSum(big, x, y);
                }
                v++;
                for (int i = 0; i < h && sum <= input; i++)
                {
                    y--;
                    big[x, y] = sum = GetSum(big, x, y);
                }
                h++;
                for (int i = 0; i < v && sum <= input; i++)
                {
                    x++;
                    big[x, y] = sum = GetSum(big, x, y);
                }
                v++;
            }

            Console.WriteLine(sum);
        }

        public static int GetSum(int[,] big, int x, int y)
        {
            return big[x - 1, y] + big[x + 1, y] + big[x - 1, y - 1] + +big[x - 1, y + 1] + big[x + 1, y - 1] + big[x + 1, y + 1] + big[x, y + 1] + big[x, y - 1];
        }
    }
}
