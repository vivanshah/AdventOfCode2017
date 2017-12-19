using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day16
    {

        static int startIndex = 0;
        public static string Calculate1()

        {
            List<char> programs = new List<char>(16) { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            //List<char> programs = new List<char>(16) { 'a', 'b', 'c', 'd', 'e'};
            Console.WriteLine("Day16 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day16.txt");
            //lines[0] = "s1,x3/4,pe/b";

            for (int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                var words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Dance(1,words, ref programs);

            }
            return string.Join("",programs);
        }

        static void Dance(int times, IEnumerable<string> words, ref List<char> programs)
        {
            for (int x = 0; x < times; x++)
            {
                foreach (var word in words)
                {
                    if (word.StartsWith("s"))
                    {
                        Rotate(ref programs, int.Parse(word.Replace("s", string.Empty)));
                    }
                    else if (word.StartsWith("x"))
                    {
                        var bits = word.TrimStart('x').Split('/');
                        var a = int.Parse(bits[0]);
                        var b = int.Parse(bits[1]);
                        Exchange(programs, a, b);
                    }
                    else if (word.StartsWith("p"))
                    {
                        var bits = word.Substring(1, word.Length - 1).Split('/');
                        Partner(programs, bits[0][0], bits[1][0]);
                    }

                    // Console.WriteLine(string.Format("{0}: {1}", word, String.Join("", programs)));
                    // Console.ReadLine();
                }
            }
        }
        static void Rotate(ref List<char> programs, int x )
        {
            var temp = new List<char>(programs);
            programs = programs.Skip(programs.Count - x).Take(x).ToList();
            programs.AddRange(temp.Take(temp.Count-x));
            //startIndex = (programs.Count - x) % programs.Count;

        }
        static void Partner (List<char> programs, char a, char b)
        {
            var iA = programs.IndexOf(a);
            var ib = programs.IndexOf(b);
            Exchange(programs, iA, ib);

        }
        static void Exchange(List<char> programs, int a, int b)
        {

            char temp = programs[a];
            programs[a] = programs[b];
            programs[b] = temp;

        }


        public static string Calculate2()
        {
            var programs = new List<char>(16) { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            Console.WriteLine("Day16 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day16.txt");
            var seen = new List<string>();

            var input = lines[0];
            var words = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            for (x = 0; x < 1000000000; x++)
            {
                Dance(1,words, ref programs);
                if (seen.Contains(string.Join("",programs)))
                {
                    Console.WriteLine("found a loop "+ x);
                    break;
                }
                seen.Add(string.Join("", programs));
            }
            x = 1000000000 % x;
            programs = seen[x - 1].ToCharArray().ToList();

            return string.Join("", programs);
        }

    }


}


