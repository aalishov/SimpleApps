
namespace FlightManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Flight
    {
        public Flight()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reservations = new HashSet<Reservation>();
        }
        public string Id { get; set; }

        public string LeavingFrom { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        [ForeignKey(nameof(Plane))]
        public string PlaneId { get; set; }

        public Plane Plane { get; set; }

        public string Pylot { get; set; }

        public int PassengersEconomy { get; set; }

        public int PassengersBussines { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
