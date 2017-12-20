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
    static class Day20
    {

        public static string Calculate1()

        {
            Console.WriteLine("Day20 part 1");
            var lines = File.ReadAllLines("..\\..\\Input\\Day20.txt");
            List<Particle> particles = new List<Particle>();
            for(int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                var parts = line.Split(new char[] { ',','=','p','v','a','<','>',' ' }, StringSplitOptions.RemoveEmptyEntries).Select(p=>long.Parse(p)).ToList();
                particles.Add(new Particle()
                {
                    id = x,
                    xPos = parts[0],
                    yPos = parts[1],
                    zPos = parts[2],
                    xVel = parts[3],
                    yVel = parts[4],
                    zVel = parts[5],
                    xAccel = parts[6],
                    yAccel = parts[7],
                    zAccel = parts[8]
                });
            }

            var minParticle = particles[0];
            int count = 0;
            while (true)
            {
                particles.ForEach(p => p.Tick());

                var newMin = particles.OrderBy(p => p.GetDistance()).First();
                if (newMin != minParticle)
                {
                    minParticle = newMin;
                } else
                {
                    count++;
                    if(count > 500)
                    {
                        break;
                    }
                }
            }

            return minParticle.id.ToString();
        }



        public static string Calculate2()
        {
            Console.WriteLine("Day20 part 2");
            var lines = File.ReadAllLines("..\\..\\Input\\Day20.txt");
            List<Particle> particles = new List<Particle>();
            for (int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                var parts = line.Split(new char[] { ',', '=', 'p', 'v', 'a', '<', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(p => long.Parse(p)).ToList();
                particles.Add(new Particle()
                {
                    id = x,
                    xPos = parts[0],
                    yPos = parts[1],
                    zPos = parts[2],
                    xVel = parts[3],
                    yVel = parts[4],
                    zVel = parts[5],
                    xAccel = parts[6],
                    yAccel = parts[7],
                    zAccel = parts[8]
                });
            }

            var minParticle = particles[0];
            int count = 0;
            while (true)
            {
                particles.ForEach(p => p.Tick());
                var collisions = particles.GroupBy(x => x.GetPosition()).Where(x => x.Count() > 1).ToDictionary(g => g.Key, g => g.ToList());
                if(collisions.Count() == 0)
                {
                    count++;
                    if(count > 500)
                    {
                        break;
                    }
                }
                foreach (var c in collisions)
                {
                    foreach (var bad in c.Value)
                    {
                        particles.Remove(bad);
                    }
                }
                var newMin = particles.OrderBy(p => p.GetDistance()).First();
                if (newMin != minParticle)
                {
                    minParticle = newMin;
                }
            }
            return particles.Count().ToString();
        }
    }

    public class Particle
    {
        public int id { get; set; }
        public long xPos { get; set; }
        public long yPos { get; set; }
        public long zPos { get; set; }

        public long xVel { get; set; }
        public long yVel { get; set; }
        public long zVel { get; set; }

        public long xAccel { get; set; }
        public long yAccel { get; set; }
        public long zAccel { get; set; }

        public void Tick()
        {
            xVel += xAccel;
            yVel += yAccel;
            zVel += zAccel;

            xPos += xVel;
            yPos += yVel;
            zPos += zVel;
        }

        public long GetDistance()
        {
            return Math.Abs(xPos) + Math.Abs(yPos) + Math.Abs(zPos);
        }

        public override bool Equals(object obj)
        {
            return (obj as Particle).id == this.id;
        }

        public string GetPosition()
        {
            return string.Join(",", xPos, yPos, zPos);
        }

    }

}


