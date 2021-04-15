using System;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.ViewModels
{
    public class CreateFlightVM
    {
        [Required]
        [Display(Name = "Leaving from")]
        public string LeavingFrom { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Departure date and time")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Arrival date and time")]
        public DateTime ArrivalDateTime { get; set; }

        [Required]
        [Display(Name = "Plane number")]
        public string PlaneNumber { get; set; }

        [Required]
        public string Pylot { get; set; }

        [Required]
        [Display(Name = "Economy class capacity")]
        public int PassengersEconomy { get; set; }

        [Display(Name = "Bussines class capacity")]
        public int PassengersBussines { get; set; }
    }
}
