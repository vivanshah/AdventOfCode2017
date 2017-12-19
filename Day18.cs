using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    static class Day18
    {

        public static string Calculate1()

        {
            Console.WriteLine("Day18 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day18.txt");
            var registers = new Dictionary<char, long>();
            var alph = "abcdefghijklmnopqrstuvwxyz";
            foreach(var c in alph)
            {
                registers.Add(c, 0);
            }

            long lastfreq = 0;
            for (long x = 0; x < lines.Length;)
            {
                var line = lines[x];
                var words = line.Split();
                var instruction = words[0];

                char register = '_';
                bool isreg = false;
                long value = 0;

                    if(char.TryParse(words[1], out register))
                    {
                        isreg = true;
                    if (char.IsNumber(register))
                    {
                        isreg = false;
                        value = (int)char.GetNumericValue(register);
                    }
                    } else
                    {
                        long.TryParse(words[1], out value);
                    }

                long v = 0;
                if (words.Length > 2) {
                    if (long.TryParse(words[2], out v))
                    {
                        v = long.Parse(words[2]);
                    } else
                    {
                        v = registers[words[2][0]];
                    }
                }
                //Console.WriteLine(string.Format("{0} {1} {2} {3} {4}",x, instruction, register, value, v));
                switch (instruction)
                {
                    case "snd":
                        lastfreq = registers[register];
                        break;
                    case "set":
                        registers[register] = v;
                        break;
                    case "add":
                        registers[register] = registers[register] + v;
                        break;
                    case "mul":
                        registers[register] = registers[register] * v;
                        break;
                    case "mod":
                        registers[register] = registers[register] % v;
                        break;
                    case "rcv":
                        if((isreg ? registers[register] : value) != 0)
                        {
                            return lastfreq.ToString();
                        }
                        break;
                    case "jgz":
                        if((isreg ? registers[register] : value) > 0)
                        {
                            x = (x + v)-1;
                        }
                        break;
                }

                x++;
            }
            return "";
        }



        public static string Calculate2()
        {
            Console.WriteLine("Day18 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day18.txt");
            var q1 = new ConcurrentQueue<long>();
            var q2 = new ConcurrentQueue<long>();
            var p0 = new DuetProgram(0, lines, q1, q2);
            var p1 = new DuetProgram(1, lines, q2, q1);

            while (true)
            {
                if (!p0.Run())
                {
                    break;
                }
                if (!p1.Run())
                {
                    break;
                }
                if(p0.sendQueue.Count == 0 && p1.sendQueue.Count == 0)
                {
                    break;
                }
            }



            return p1.sendCount.ToString();
        }

    }

    public class DuetProgram
    {

        string[] lines;
        public int sendCount = 0;
        public Dictionary<char,long> registers = new Dictionary<char, long>();
        public int id;
        long instr = 0;
        public ConcurrentQueue<long> sendQueue, receiveQueue;
        public DuetProgram(int id, string[] instructions, ConcurrentQueue<long> sendQueue, ConcurrentQueue<long> receiveQueue)
        {
            this.id = id;
            this.sendQueue = sendQueue;
            this.receiveQueue = receiveQueue;
            lines = instructions;
            var alph = "abcdefghijklmnopqrstuvwxyz";
            foreach (var c in alph)
            {
                registers.Add(c, 0);
            }
            registers['p'] = id;

        }

        public bool Run()
        {
            while (true)
            {
                var line = lines[instr];
                var words = line.Split();
                var instruction = words[0];

                char register = '_';
                bool isreg = false;
                long value = 0;

                if (char.TryParse(words[1], out register))
                {
                    isreg = true;
                    if (char.IsNumber(register))
                    {
                        isreg = false;
                        value = (int)char.GetNumericValue(register);
                    }
                }
                else
                {
                    long.TryParse(words[1], out value);
                }

                long v = 0;
                if (words.Length > 2)
                {
                    if (long.TryParse(words[2], out v))
                    {
                        v = long.Parse(words[2]);
                    }
                    else
                    {
                        v = registers[words[2][0]];
                    }
                }
                //Console.WriteLine(string.Format("{0} {1} {2} {3} {4}",x, instruction, register, value, v));
                switch (instruction)
                {
                    case "snd":
                        sendCount++;
                        sendQueue.Enqueue(registers[register]);
                        break;
                    case "set":
                        registers[register] = v;
                        break;
                    case "add":
                        registers[register] = registers[register] + v;
                        break;
                    case "mul":
                        registers[register] = registers[register] * v;
                        break;
                    case "mod":
                        registers[register] = registers[register] % v;
                        break;
                    case "rcv":
                        if (receiveQueue.Count == 0)
                        {
                            return true;
                        }
                        long incoming;
                        receiveQueue.TryDequeue(out incoming);
                        registers[register] = incoming;
                        break;
                    case "jgz":
                        if ((isreg ? registers[register] : value) > 0)
                        {
                            instr = (instr + v) - 1;
                        }
                        break;
                }

                instr++;
            }
        }
    }


}


