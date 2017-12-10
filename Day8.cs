using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    static class Day8
    {
        public static string Calculate1()
        {
            Console.WriteLine("Day8 part 1");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day8.txt");
            var registers = new Dictionary<string, int>();

            foreach(var line in lines)
            {
                var words = line.Split();
                var dest = words[0];
                var operation = words[1];
                var value = int.Parse(words[2]);
                if (!registers.ContainsKey(dest))
                {
                    registers.Add(dest, 0);
                }
                var check = words[4];
                var comparison = words[5];
                var compareValue = int.Parse(words[6]);

                int checkValue = 0;
                if (registers.ContainsKey(check))
                {
                    checkValue = registers[check];
                } else
                {
                    registers.Add(check, 0);
                }
                bool doOperation = false;
                switch (comparison)
                {
                    case ">":
                        if(checkValue > compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "<":
                        if (checkValue < compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case ">=":
                        if (checkValue >= compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "<=":
                        if (checkValue <= compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "==":
                        if (checkValue == compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "!=":
                        if (checkValue != compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                }
                if (doOperation)
                {
                    if (!registers.ContainsKey(dest))
                    {
                        registers.Add(dest, 0);
                    }

                        switch (operation)
                        {
                            case "inc":
                                registers[dest] += value;
                                break;
                            case "dec":
                                registers[dest] -= value;
                                break;
                        }
                }
                
            }
            result = registers.Values.Max().ToString();
            return result;
        }

        public static string Calculate2()
        {
            Console.WriteLine("Day8 part 2");
            string result = null;
            var lines = File.ReadAllLines("..\\..\\Input\\Day8.txt");
            var registers = new Dictionary<string, int>();
            int max = Int32.MinValue;
            foreach (var line in lines)
            {
                var words = line.Split();
                var dest = words[0];
                var operation = words[1];
                var value = int.Parse(words[2]);
                if (!registers.ContainsKey(dest))
                {
                    registers.Add(dest, 0);
                }
                var check = words[4];
                var comparison = words[5];
                var compareValue = int.Parse(words[6]);

                int checkValue;
                if (!registers.ContainsKey(check))
                {
                    registers.Add(check, 0);
                }
                checkValue = registers[check];

                bool doOperation = false;
                switch (comparison)
                {
                    case ">":
                        if (checkValue > compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "<":
                        if (checkValue < compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case ">=":
                        if (checkValue >= compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "<=":
                        if (checkValue <= compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "==":
                        if (checkValue == compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                    case "!=":
                        if (checkValue != compareValue)
                        {
                            doOperation = true;
                        }
                        break;
                }
                if (doOperation)
                {
                    switch (operation)
                    {
                        case "inc":
                            registers[dest] += value;
                            break;
                        case "dec":
                            registers[dest] -= value;
                            break;
                    }
                }
                if (registers[dest] > max)
                {
                    max = registers[dest];
                }

            }
            //result = registers.Values.Max().ToString();
            result = max.ToString();
            return result;
        }
    }
}
