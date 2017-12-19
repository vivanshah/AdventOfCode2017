using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode2017
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            

            int day = DateTime.Now.Day;
            Console.SetBufferSize(400, 10000);
            Console.SetWindowSize(180, 45);
            var sw = new Stopwatch();
            Console.WriteLine("Day " + day + Environment.NewLine);
            var inputFilename = "..\\..\\Input\\Day" + day + ".txt";
            if (!File.Exists(inputFilename) && DateTime.Now.Hour == 0)
            {
                WebClient w = new WebClient();
                w.Headers.Add(HttpRequestHeader.Cookie, "session=53616c7465645f5f5c5040c46e4a65d6ad2572be75c10f2fcc8e7b6428be2b2a40d99eb3127e4675bdc0c3afca7745ce");
                var input = w.DownloadString("http://adventofcode.com/2017/day/" + day + "/input").Replace("\n",Environment.NewLine);
                File.WriteAllText(inputFilename, input);
            }

            var today = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals("Day"+day));

             sw.Start();
             var part1 = today.GetMethod("Calculate1")?.Invoke(null, null);
             sw.Stop();
             Console.WriteLine(part1);
             Clipboard.SetText(part1.ToString());
             Console.WriteLine("part 1 value in clipboard, completed in " + sw.ElapsedMilliseconds + " ms");
            Console.ReadLine();
            sw.Restart();
            string part2Result = null;
            var part2 = today.GetMethod("Calculate2");
            if(part2 != null)
            {
                part2Result = Convert.ToString(part2.Invoke(null, null));
            }
            sw.Stop();
            if (part2Result != null)
            {
                Console.WriteLine(part2Result);
                Clipboard.SetText(part2Result.ToString());
                Console.WriteLine("part 2 value in clipboard, completed in " + sw.ElapsedMilliseconds + " ms");
                Console.WriteLine("\r\n\r\nFinished");
                Console.ReadLine();
            }

            
        }
    }
}
