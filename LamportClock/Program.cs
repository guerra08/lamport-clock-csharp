using System;
using System.Linq;

namespace LamportClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Lamport lamport = new Lamport();

            Event e1 = new Event(1, "First", null);
            Event e2 = new Event(2, "Second", null);
            Event e3 = new Event(3, "Third", 9);

            lamport.receive(e1);
            lamport.receive(e3);
            lamport.receive(e2);

            Console.WriteLine("All events: " + String.Join("", lamport.Events));

            Console.WriteLine(String.Format("Current server clock: {0}", lamport.Clock));

            Console.WriteLine(String.Format("Events ordered by time: \n{0}", 
                String.Join("", lamport.Events.OrderBy(x => x.Clock.Value).ToList())));
        }
    }
}
