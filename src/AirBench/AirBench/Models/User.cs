using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBench.Models
{
    public class User
    {
        public User()
        {
            Benches = new List<Bench>();
            Reviews = new List<Review>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }

        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{FirstName} {LastName.Substring(0, 1)}.";
            }
        }
    }
}