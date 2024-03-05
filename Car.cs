using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Tradar
{
    public class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; } = 120;
        public double KmTravelled { get; set; } = 0;
        public bool HaventFinished { get; set; } = true;

        public void DriveCar(ManualResetEvent myEvent)
        {
            int RandomeventTimer = 0;
            int SecondsPassed = 0;
            double MetersTravelled = 0;
            double MeterPerSecConvertNumber = 0.2777;

            do
            {
                double MetersPerSecond = Speed * MeterPerSecConvertNumber;
                MetersTravelled = MetersTravelled + MetersPerSecond;
                KmTravelled = MetersTravelled / 1000;
                RandomeventTimer++;
                SecondsPassed++;
               

                if (RandomeventTimer == 30)
                {
                    RandomEvent();
                    RandomeventTimer = 0;
                }

                Thread.Sleep(1000);
            } while (KmTravelled < 10);

            Console.WriteLine($"{Name} has reached the finish line!");
            HaventFinished = false;
            myEvent.Set();
        }

        public void RandomEvent()
        {
            Random rnd = new Random();
            int RandomNumb = rnd.Next(1, 50);

            if(RandomNumb == 1)
            {
                Console.WriteLine($"{Name} is out of gas, refuelling for 30 seconds");
                Thread.Sleep(30000);
            }
            else if (RandomNumb == 2 || RandomNumb == 3)
            {
                Console.WriteLine($"{Name} is taking a 20 second pit stop to change tires");
                Thread.Sleep(20000);
            }
            else if (RandomNumb >= 4 && RandomNumb <= 8) 
            {
                Console.WriteLine($"{Name} got a bird on their windshield and is taking 10 seconds to wipe it off");
                Thread.Sleep(10000);
            }
            else if (RandomNumb >= 9 && RandomNumb <= 19)
            {
                Console.WriteLine($"{Name}s engine is overheating and is driving 1 km/h slower");
                Speed = Speed - 1;
            }
        }
    }

}
