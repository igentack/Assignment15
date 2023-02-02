using Bogus;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private static LmsDataContext db;

        public static async Task InitAsync(LmsDataContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));
            db = context;

            if (await db.Tournament.AnyAsync()) return;

            var faker = new Faker("sv");
            var events = new List<Tournament>();


            for (int i = 0; i < 50; i++)
            {
                events.Add(new Tournament

                {
                    Title = faker.Company.CompanySuffix() + faker.Random.Word(),
                    StartDate = DateTime.Now.AddDays(faker.Random.Int(-20, 20)),
                    Games = new Game[] {
                    new Game
                    {
                        Title = faker.Company.CompanyName(),
                        Time = DateTime.Now.AddHours(faker.Random.Int(-20, 20)),     
                    },
                   }

                });

            }

            db.AddRange(events);
            await db.SaveChangesAsync();


        }
    }
}
