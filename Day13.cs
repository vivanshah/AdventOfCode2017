using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day13
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day13 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day13.txt");
            //var lines = new List<string>() { "0: 3", "1: 2", "4: 4", "6: 4" };
            int[] firewall = new int[100];
            int[] maxDepth = new int[100];
            int[] direction = new int[100];
            bool[] exists = new bool[100];
            int maxLayer = 0;
            for(int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                var words = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var layer = int.Parse(words.First());
                var depth = int.Parse(words.Last());
                exists[layer] = true;
                firewall[layer] = 0;
                maxDepth[layer] = depth-1;
                direction[layer] = 1;
                if(layer > maxLayer)
                {
                    maxLayer = layer;
                }
            }
            int packet = -1;
            int severity = 0;
            for(int x = 0; x < maxLayer+1; x++)
            {
                packet++;
                if (packet > -1 && firewall[packet] == 0 && exists[packet])
                {
                    severity += (maxDepth[x]+1) * x;
                }


                for(int f = 0; f < maxLayer+1; f++)
                {
                    if((firewall[f] == maxDepth[f] && direction[f] == 1) || (firewall[f] == 0 && direction[f] == -1))
                    {
                        direction[f] = direction[f] * -1;
                    }
                    firewall[f] += direction[f];
                }
                

            }
            return severity.ToString();
        }
      

        public static string Calculate2()
        {
            Console.WriteLine("Day13 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day13.txt");
            //var lines = new string[] { "0: 3", "1: 2", "4: 4", "6: 4" };
            
            int[] maxDepth = new int[100];
            bool[] exists = new bool[100];
            int maxLayer = 0;
            for (int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                var words = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var layer = int.Parse(words.First());
                var depth = int.Parse(words.Last());
                exists[layer] = true;
                maxDepth[layer] = depth - 1;
                if (layer > maxLayer)
                {
                    maxLayer = layer;
                }
            }
            for (int d = 1; d < Int32.MaxValue; d++)
            {
                bool caught = false;
                for (int x = 0; x < maxLayer + 1; x++)
                {
                    if (!exists[x])
                    {
                        continue;
                    }
                    if (((d+x) % ((maxDepth[x]) * 2) == 0))
                    {
                        caught = true;
                        break;
                    }
                }
                if (!caught)
                {
                    return (d).ToString();
                }
            }
            return String.Empty;
        }
    }


}

