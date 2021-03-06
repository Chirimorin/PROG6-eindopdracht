﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class AlternatePrice
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        public Room Room { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal NewPrice { get; set; }
    }
}