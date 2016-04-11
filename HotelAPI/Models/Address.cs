using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}