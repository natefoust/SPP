using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2
{
    class Program
    {
        public class Hand
        {
            public float rotation { get; set; }
            protected int time { get; set; }

            public Hand(int time, bool isHours)
            {
                if (isHours)
                {
                    if (time >= 12 && time < 24) time /= 2;
                    this.time = time;
                    rotation = 360 * ((float)time / 12);
                }
                else
                {
                    this.time = time;
                    rotation = 360 * ((float)time / 1440);
                }
            }

            public int print()
            {
                return time;
            }

            Hand(float rotation)
            {
                this.rotation = rotation;
                time = (int)(rotation / 360 * 86400);
            }

            public float getRotation()
            {
                return rotation;
            }

            public int getTime()
            {
                return time;
            }
        }

        public class Clock
        {
            Hand hour { get; set; }
            Hand minute { get; set; }
            DateTime time1 { get; set; }

            public Clock()
            {
                this.time1 = DateTime.Now;
                this.hour = new Hand(time1.Hour, true);
                this.minute = new Hand(time1.Minute, false);
            }

            void print()
            {
                Console.WriteLine("Time: " + time1);
                Console.WriteLine("Hour hand: " + hour.print() + ", " + hour.rotation);
                Console.WriteLine("Minute hand: " + minute.print() + ", " + minute.rotation);
            }
            static void Main(string[] args)
            {
                Clock clock = new Clock();
                clock.print();
                Console.ReadKey();
            }
        }
    }
}