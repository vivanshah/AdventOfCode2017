using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day12
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day12 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day12.txt");
            var dict = new Dictionary<int, Node>();
            Node nodeZero = null;
            for(int x = 0; x < lines.Length; x++)
            {
                var line = lines[x].Replace("<->",",");

                var words = line.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
                var root = int.Parse(words[0]);
                Node r = null;
                if (!dict.ContainsKey(root))
                {
                    r = new Node() { value = root, Edges = new List<Node>() };
                    dict.Add(root, r);
                }
                else
                {
                    r = dict[root];
                }
                for(int w = 1; w < words.Length; w++)
                {
                    Node c = null;
                    var v = int.Parse(words[w]);
                    if (!dict.ContainsKey(v))
                    {
                        c = new Node() { value = v, Edges = new List<Node>() };
                        dict.Add(v, c);
                    } else
                    {
                        c = dict[v];
                    }
                    r.Edges.Add(c);
                }
                if(r.value == 0)
                {
                    nodeZero = r;
                }
                
            }

            int count = Dfs(nodeZero);


            return count.ToString();
        }
        static HashSet<int> visited = new HashSet<int>();
        public static int Dfs(Node nodeZero)
        {
            var stack = new Stack<Node>();
            int count = 0;
            stack.Push(nodeZero);
            while(stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex.value))
                {
                    continue;
                } else
                {
                    visited.Add(vertex.value);
                    count++;
                }
                foreach(var n in vertex.Edges)
                {
                    if (!visited.Contains(n.value))
                    {
                        stack.Push(n);
                    }
                }

            }
            return count;
        }

        public static bool IsNewGroup(Node nodeZero)
        {
            var existingCount = visited.Count;
            var stack = new Stack<Node>();
            int count = 0;
            stack.Push(nodeZero);
            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex.value))
                {
                    continue;
                }
                else
                {
                    visited.Add(vertex.value);
                    count++;
                }
                foreach (var n in vertex.Edges)
                {
                    if (!visited.Contains(n.value))
                    {
                        stack.Push(n);
                    }
                }

            }
            if(visited.Count > existingCount){
                return true;
            }
            return false;
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day12 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day12.txt");
            var dict = new Dictionary<int, Node>();
            Node nodeZero = null;
            for (int x = 0; x < lines.Length; x++)
            {
                var line = lines[x].Replace("<->", ",");

                var words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var root = int.Parse(words[0]);
                Node r = null;
                if (!dict.ContainsKey(root))
                {
                    r = new Node() { value = root, Edges = new List<Node>() };
                    dict.Add(root, r);
                }
                else
                {
                    r = dict[root];
                }
                for (int w = 1; w < words.Length; w++)
                {
                    Node c = null;
                    var v = int.Parse(words[w]);
                    if (!dict.ContainsKey(v))
                    {
                        c = new Node() { value = v, Edges = new List<Node>() };
                        dict.Add(v, c);
                    }
                    else
                    {
                        c = dict[v];
                    }
                    r.Edges.Add(c);
                }
                if (r.value == 0)
                {
                    nodeZero = r;
                }

            }
            int count = 0;
            visited = new HashSet<int>();
            foreach(var n in dict.Keys)
            {
                var node = dict[n];
                count += IsNewGroup(node) ? 1 : 0;
            }


            return count.ToString();
        }
    }

    public class Node
    {
        public int value { get; set; }
        public List<Node> Edges { get; set; }
    }
}

