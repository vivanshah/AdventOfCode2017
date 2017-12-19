using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day10
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day10 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day10.txt");
            int skipSize = 0;
            var line = lines[0];

            int c = 0;
            var words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            var array = new int[256];

            for (int x = 0; x < array.Length; x++)
            {
                array[x] = x;
            }
            for (int x = 0; x < words.Length; x++)
            {
                int length = words[x];
                if(c + length > array.Length)
                {
                    var tmp = new int[length];
                    for(int i = 0;i<length;i = (i + 1))
                    {
                        tmp[i] = array[(c+i) % array.Length];
                    }
                    Array.Reverse(tmp);
                    for(int i = 0, y = 0 ; y < length; i = (i + 1), y++)
                    {
                        array[(c+i) % array.Length] = tmp[y];
                    }
                } else
                {
                    Array.Reverse(array, c, length);
                }
                c += length + skipSize;
                c = c % array.Length;
                skipSize++;
            }
            result = (array[0] * array[1]).ToString();
            return result;
        }

        public static string Calculate2(string input = null)
        {
           // Console.WriteLine("Day10 part 2");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day10.txt");
            int skipSize = 0;
            var line = input ?? lines[0];
            var bytes = Encoding.UTF8.GetBytes(line).ToList();
            bytes.AddRange(new List<byte>() { 17, 31, 73, 47, 23 });
            int c = 0;
            var words = bytes.Select(x => Convert.ToInt32(x)).ToArray();
            var array = Enumerable.Range(0, 256).ToArray();

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
            for(int x = 0; x < denseHash.Length; x++)
            {
                var chunk = array.Skip(16 * x).Take(16).ToArray();
                denseHash[x] = 0;
                foreach(var hash in chunk)
                {
                    denseHash[x] ^= hash;
                }
            }

            result = string.Join("", denseHash.Select(x => x.ToString("X2"))).ToLower();
            return result;
        }
    }
}
