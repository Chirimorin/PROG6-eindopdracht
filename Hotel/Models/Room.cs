using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int NumPersons { get; set; }

        // Price in cents (to prevent issues with rounding)
        [Required]
        public int MinPrice { get; set; }

        public List<AlternatePrice> AlternatePrices { get; set; }
    }
}