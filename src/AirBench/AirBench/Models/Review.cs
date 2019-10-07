using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBench.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public int BenchId { get; set; }
        public Bench Bench { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}