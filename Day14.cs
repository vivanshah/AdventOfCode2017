using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day14
    {
        static int[,] disk = new int[128,128];
        static int[] rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        public static string Calculate1()
        {
            Console.WriteLine("Day14 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day14.txt");
            //var input = lines[0] + "-";
            var input = "hxtvlmkl-";
            int count = 0;
            for (int x = 0;x < 128; x++)
            {
                var hash = Day10.Calculate2(input + x.ToString());

                count += CountBits(hash, x);

            }


            int numGroups = countIslands(disk);

            return numGroups.ToString() ;
        }

        public static int countIslands(int[,] sea)
        {
            bool[,] visited = new bool[sea.GetLength(0),sea.GetLength(1)];
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    visited[i,j] = false;
		    	}
            }
		    return countIslands(sea, visited);
	    }
	
	public static int countIslands(int[,] sea, bool[,] visited)
{
    int numOfIslands = 0;
    for (int i = 0; i < sea.GetLength(0); i++)
    {
        for (int j = 0; j < sea.GetLength(1); j++)
        {
            if (visited[i,j])

                    continue;
            if (sea[i,j] == 0)
            {
                visited[i,j] = true;
					continue;
				}
				numOfIslands++;

                floodFill(i, j, sea, visited); 
			}
		}
		return numOfIslands;
	}
	
	public static void floodFill(int row, int col, int[,] sea, bool[,] visited)
{
    if (sea[row,col] == 0 || visited[row,col]) return;
    visited[row,col] = true;
		if (col<sea.GetLength(1) - 1) floodFill(row, col+1, sea, visited);
		if (row<sea.GetLength(0) - 1) floodFill(row+1, col, sea, visited);
		if (col > 0) floodFill(row, col-1, sea, visited);
		if (row > 0) floodFill(row-1, col, sea, visited);
	}

        public static int CountBits(string input, int row)
        {
            string binarystring = String.Join(String.Empty,
              input.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );
            for(int c = 0; c < 128; c++)
            {
                disk[row, c] = (int) char.GetNumericValue(binarystring[c]);
            }
            return binarystring.Count(s => s == '1');

        }

        public static string Calculate2()
        {
            Console.WriteLine("Day14 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day14.txt");

            return string.Empty;
        }

        public static string KnotHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input).ToList();
            int c = 0;
            var words = bytes.Select(x => Convert.ToInt32(x)).ToArray();
            var array = Enumerable.Range(0, 256).ToArray();
            bytes.AddRange(new List<byte>() { 17, 31, 73, 47, 23 });
            int skipSize = 0;
            for (int z = 0; z < 64; z++)
            {
                for (int x = 0; x < words.Length; x++)
                {
                    int length = words[x];
                    if (c + length > array.Length)
                    {
                        var tmp = new int[length];
                        for (int i = 0; i < length; i = (i + 1))
                        {
                            tmp[i] = array[(c + i) % array.Length];
                        }
                        Array.Reverse(tmp);
                        for (int i = 0, y = 0; y < length; i = (i + 1), y++)
                        {
                            array[(c + i) % array.Length] = tmp[y];
                        }
                    }
                    else
                    {
                        Array.Reverse(array, c, length);
                    }
                    c += length + skipSize;
                    c = c % array.Length;
                    skipSize++;
                }
            }

            int[] denseHash = new int[16];
            for (int x = 0; x < denseHash.Length; x++)
            {
                var chunk = array.Skip(16 * x).Take(16).ToArray();
                denseHash[x] = 0;
                foreach (var hash in chunk)
                {
                    denseHash[x] ^= hash;
                }
            }

            return string.Join("", denseHash.Select(x => x.ToString("X"))).ToLower();
        }
    }


}

