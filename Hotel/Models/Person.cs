using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public Gender Gender { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}