using AdventOfCode2017;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day19
    {

        public static string Calculate1()

        {
            Console.WriteLine("Day19 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day19.txt");
            char[,] route = new char[lines.Length, lines[0].Length];
            int startCol = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0;j<lines[i].Length;j++)
                {
                    char c = lines[i][j];
                    route[i, j] = c;
                    if(i == 0 && c == '|')
                    {
                        startCol = j;
                    }
                }
            }
            int x = 0;
            int y = startCol;
            char direction = 'd';
            int steps = 2;
            var sb = new StringBuilder();
            while (true)
            {
                
                switch (direction)
                {
                    case 'd':
                        x++;
                        break;
                    case 'u':
                        x--;
                        break;
                    case 'l':
                        y--;
                        break;
                    case 'r':
                        y++;
                        break;
                    default:
                        break;
                }

                if(x > route.GetLength(0)-1 || x < 0 || y > route.GetLength(1)-1 || y < 0)
                {
                    break;
                }
                char r = route[x, y];
                if(r != '|' && r != ' ' && r != '+' && r != '-')
                {
                    sb.Append(r);
                }
                if (char.IsLetter(r))
                {
                    Console.WriteLine(r);
                    if (CheckEnd(route, x, y))
                    {
                        break;
                    }
                    if (x > route.GetLength(0) - 1 || x < 0 || y > route.GetLength(1) - 1 || y < 0)
                    {
                        break;
                    }
                }
                if(r == '+')
                {
                    char newDirection = GetDirection(direction, route, x, y);
                    direction = newDirection;
                }
                steps++;

            }


            return steps.ToString() ;
        }
        public static bool CheckEnd(char[,] route, int x, int y)
        {
            var sb = new StringBuilder();
            if(x+1 < route.GetLength(0)-1)
                sb.Append(route[x + 1, y]);
            if (x -1 > -1)
                sb.Append(route[x - 1, y]);

            if (y + 1 < route.GetLength(1) - 1)
                sb.Append(route[x, y +1]);
            if (y - 1 > -1)
                sb.Append(route[x, y - 1]);
            var list = sb.ToString().ToList();

            if(list.Where(c=>c == ' ').Count() == 3)
            {
                return true;
            }
            return false;
        }
        public static char GetDirection(char oldDirection, char[,] route, int x, int y)
        {

            switch (oldDirection)
            {
                case 'd':
                case 'u':
                    if (route[x, y - 1] == ' ')
                    {
                        return 'r';
                    }
                    else
                    {
                        return 'l';
                    }
                case 'l':
                case 'r':
                    if (route[x-1, y] == ' ')
                    {
                        return 'd';
                    }
                    else
                    {
                        return 'u';
                    }
                default:
                    throw new Exception("bad direction");
            }

        }


        public static string Calculate2()
        {
            Console.WriteLine("Day19 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day19.txt");
 
            return "";
        }

    }

   
}


