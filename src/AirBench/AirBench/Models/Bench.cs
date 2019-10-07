using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBench.Models
{
    public class Bench
    {
        public Bench()
        {
            Reviews = new List<Review>();
        }

        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Review> Reviews { get; set; }

        public string ShortDescription
        {
            get
            {
                string description = Description;
                string shortDescription = string.Empty;

                // Make sure that we have a description...
                if (!string.IsNullOrWhiteSpace(description))
                {
                    // Get a collection of the words in the description.
                    var words = description
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // If we have more than 10 words
                    // then take the first 10 and add "..." to the end
                    // otherwise just use the description as is. 
                    if (words.Length > 10)
                    {
                        shortDescription = string.Join(" ", words.Take(10)) + "...";
                    }
                    else
                    {
                        shortDescription = description;
                    }
                }

                return shortDescription;
            }
        }

        public double? AverageRating
        {
            get
            {
                if (Reviews.Count > 0)
                {
                    return Math.Round(Reviews.Average(r => r.Rating), 1);

                    //decimal sum = 0;
                    //foreach (var review in Reviews)
                    //{
                    //    sum += review.Rating;
                    //}
                    //return Math.Round(sum / Reviews.Count, 1);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}