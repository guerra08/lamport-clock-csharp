using System.Collections.Generic;

namespace LamportClock
{
    class Lamport
    {

        public int Clock { get; set; }
        public List<Event> Events { get; set; }

        public Lamport()
        {
            Clock = 0;
            Events = new List<Event>();
        }

        public void receive(Event e)
        {
            if (!e.Clock.HasValue)
            {
                e.Clock = Clock;
            }
            Events.Add(e);
            Clock = e.Clock.Value + 1;
        }
    }
}
