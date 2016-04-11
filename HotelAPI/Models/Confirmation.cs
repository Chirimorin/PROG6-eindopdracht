using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Confirmation
    {
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public int AddressId { get; set; }
        public Address BillingAddress { get; set; }

        [Required]
        public int BankNumber { get; set; }
    }
}