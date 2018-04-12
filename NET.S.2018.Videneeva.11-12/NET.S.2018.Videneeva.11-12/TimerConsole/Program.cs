using System;
using TimerLibrary;

namespace TimerConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Timer timer = new Timer(2000);
            Subscriber subscriber = new Subscriber(timer);

            subscriber.Timer.Start();

            Console.ReadKey();
        }
    }
}
