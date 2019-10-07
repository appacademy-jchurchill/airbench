using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AirBench.Models;

namespace AirBench.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var user1 = new User()
            {
                Email = "john@smith.com",
                FirstName = "John",
                LastName = "Smith",
                HashedPassword = "$2a$12$ctRHCe0fNXXNYz13JybBruMf40COXIhZWh8wLaVncPWIqJyYvbO8G"
            };

            var user2 = new User()
            {
                Email = "bob@jones.com",
                FirstName = "Bob",
                LastName = "Jones",
                HashedPassword = "$2a$12$ctRHCe0fNXXNYz13JybBruMf40COXIhZWh8wLaVncPWIqJyYvbO8G"
            };

            var user3 = new User()
            {
                Email = "sally@jones.com",
                FirstName = "Sally",
                LastName = "Jones",
                HashedPassword = "$2a$12$ctRHCe0fNXXNYz13JybBruMf40COXIhZWh8wLaVncPWIqJyYvbO8G"
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            var bench1 = new Bench()
            {
                Description = "Cozy Bench",
                NumberOfSeats = 2,
                Latitude = 40.755641m,
                Longitude = -73.949378m,
                CreatedOn = GetDateTimeOffset(2019, 1, 1, 12, 0),
                User = user1
            };
            bench1.Reviews.Add(new Review()
            {
                Rating = 4,
                Comment = "My favorite bench of all time.",
                User = user2,
                CreatedOn = GetDateTimeOffset(2019, 2, 2, 12, 0),
            });

            var bench2 = new Bench()
            {
                Description = "Friendly Bench",
                NumberOfSeats = 4,
                Latitude = 40.765558m,
                Longitude = -73.941097m,
                CreatedOn = GetDateTimeOffset(2019, 2, 1, 12, 0),
                User = user1
            };
            bench2.Reviews.Add(new Review()
            {
                Rating = 1,
                Comment = "Way too crowded.",
                User = user2,
                CreatedOn = GetDateTimeOffset(2019, 2, 1, 12, 0),
            });
            bench2.Reviews.Add(new Review()
            {
                Rating = 5,
                Comment = "This is the bench where I met my best friend.",
                User = user3,
                CreatedOn = GetDateTimeOffset(2019, 2, 2, 12, 0),
            });
            bench2.Reviews.Add(new Review()
            {
                Rating = 4,
                Comment = "Not too bad.",
                User = user1,
                CreatedOn = GetDateTimeOffset(2019, 2, 3, 12, 0),
            });

            var bench3 = new Bench()
            {
                Description = "Solo Bench That Has a Really Long Description In Order to Test the Code to Trim the Description",
                NumberOfSeats = 1,
                Latitude = 40.757689m,
                Longitude = -73.952812m,
                CreatedOn = GetDateTimeOffset(2019, 3, 1, 12, 0),
                User = user2
            };

            context.Benches.Add(bench1);
            context.Benches.Add(bench2);
            context.Benches.Add(bench3);
        }

        private DateTimeOffset GetDateTimeOffset(
            int year, int month, int day, int hour, int minute)
        {
            return new DateTimeOffset(year, month, day, hour, minute, 0,
                new TimeSpan(-4, 0, 0));
        }
    }
}