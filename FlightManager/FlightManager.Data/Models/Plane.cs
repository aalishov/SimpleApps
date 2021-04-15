namespace FlightManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Plane
    {
        public Plane()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Flights = new HashSet<Flight>();
        }
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string PlaneNumber { get; set; }

        public int PlaneCapacity { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
