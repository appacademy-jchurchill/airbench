using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBench.FormModels
{
    public class CreateBench
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int? NumberOfSeats { get; set; }
        [Required]
        public decimal? Latitude { get; set; }
        [Required]
        public decimal? Longitude { get; set; }

        public string Temp { get; set; }
    }
}