using AirBench.Data.Repositories;
using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AirBench.ApiControllers
{
    public class BenchesController : ApiController
    {
        private IBenchRepository repository;

        public BenchesController(IBenchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IHttpActionResult> Get()
        {
            var benches = await repository.GetList();

            var flattendBenches = benches.Select(b => new
            {
                BenchId = b.Id,
                Description = b.ShortDescription,
                NumberOfSeats = b.NumberOfSeats,
                Latitude = b.Latitude,
                Longitude = b.Longitude,
                HasReviews = b.Reviews.Count > 0,
                AverageRating = b.AverageRating,
                UserDisplayName = b.User.DisplayName
            }).ToList();

            return Ok(flattendBenches);
        }
    }
}