namespace Labb2_Tradar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int a = 2; a >= 0; a--)
            {
                Console.WriteLine(a+1);
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Go!");

            var Mustang = new Car();
            Mustang.Name = "Mustang";
            var Porsche = new Car();
            Porsche.Name = "Porsche";

            ManualResetEvent car1FinishedEvent = new ManualResetEvent(false);
            ManualResetEvent car2FinishedEvent = new ManualResetEvent(false);


            Thread MustangRace = new Thread(() => Mustang.DriveCar(car1FinishedEvent));
            Thread PorscheRace = new Thread(() => Porsche.DriveCar(car2FinishedEvent));


            MustangRace.Start();
            PorscheRace.Start();

            Console.WriteLine("Write 'status' to check on the race");

            do
            {
                string input = Console.ReadLine();
                if (input == "status")
                {
                    Console.WriteLine($"\n{Mustang.Name}s\nCurrent speed: {Mustang.Speed}\nDistance travelled: {Mustang.KmTravelled.ToString("#.00")}km" +
                                      $"\n\n{Porsche.Name}s\nCurrent speed: {Porsche.Speed}\nDistance travelled: {Porsche.KmTravelled.ToString("#.00")}km");
                }
            } while (Mustang.HaventFinished || Porsche.HaventFinished);

            WaitHandle.WaitAny(new WaitHandle[] { car1FinishedEvent, car2FinishedEvent });

            

            if (car1FinishedEvent.WaitOne(0))
            {
                Console.WriteLine("Car 1 wins!");
            }
            else
            {
                Console.WriteLine("Car 2 wins!");
            }

            MustangRace.Join();
            PorscheRace.Join();

            
        }
    }
}