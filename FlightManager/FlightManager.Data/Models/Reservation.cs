using FlightManager.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightManager.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsConfirmed = false;
            this.CreatedOn = DateTime.UtcNow;
        }
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string   MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime ConfirmedOn { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Flight))]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
