using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day7
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day7 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day7.txt");
            var programs = new List<string>();

            var basePrograms = new List<String>();
            foreach(var line in lines)
            {
                var words = line.Split();
                for(int x = 0;x < words.Length;x++)
                {
                    if(x == 0)
                    {
                        basePrograms.Add(words[x]);
                        continue;
                    }
                    if(words[x].StartsWith("(") || words[x].StartsWith("-"))
                    {
                        continue;
                    }
                    programs.Add(words[x].Replace(",", String.Empty));
                }
            }

            result = basePrograms.Except(programs).First();
            
            //result = 
            return result;
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day7 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day7.txt");
            var pd = new Dictionary<string, BaseProgram>();
            var basePrograms = new List<BaseProgram>(); 
            foreach (var line in lines)
            {
                var words = line.Split();
                var r = words[0].Trim();
                int weight = int.Parse(words[1].Replace("(", string.Empty).Replace(")", string.Empty));
                List<string> children = new List<string>();
                if (line.Contains("->"))
                {
                    children= line.Split('>')[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToList();

                }
                BaseProgram p;
                if (pd.ContainsKey(r))
                {
                    p = pd[r];
                    p.weight = weight;
                } else
                {
                    p = new BaseProgram() { name = r, programs = new List<BaseProgram>(), weight = weight };
                    pd.Add(r, p);
                }

                foreach(var c in children)
                {
                    BaseProgram child = null;
                    if (pd.ContainsKey(c))
                    {
                        child = pd[c];
                    } else
                    {
                        child= new BaseProgram() { name = c, programs = new List<BaseProgram>(), weight = -1 };
                        pd.Add(c, child);
                    }
                    p.programs.Add(child);
                }
            }
            var root = pd.Values.Except(pd.Values.SelectMany(x => x.programs)).First();

            int targetWeight = 0;
            while (true)
            {
                var groups = root.programs.GroupBy(x => x.totalweight).OrderBy(gp=> gp.Count());
                if(groups.Count() > 1)
                {
                    root = groups.First().First();
                    targetWeight = groups.Last().First().totalweight;
                } else
                {
                    var difference = root.totalweight - targetWeight;
                    result = (root.weight - difference).ToString();
                    break;
                }
            }
            return result;
        }
        public static int FindWeight(BaseProgram b)
        {
            if(b.programs == null || b.programs.Count == 0)
            {
                return 0;
            }

            var childWeights = b.programs.Select(x => x.totalweight);
            Console.WriteLine(b.weight + ", " + string.Join(",", childWeights));
            return b.totalweight;
        }
        

    }
    public class BaseProgram
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int totalweight
        {
            get
            {
                return weight + programs.Sum(x => x.totalweight);
            }
        } 
        public List<BaseProgram> programs;
    }
    public class Prog
    {
        public string name { get; set; }
    }
}
