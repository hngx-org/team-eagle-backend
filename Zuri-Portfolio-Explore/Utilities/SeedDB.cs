using Bogus;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.Models;

namespace Zuri_Portfolio_Explore.Utilities
{
    public class SeedDB
    {
        public async static Task Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var faker = new Faker<User>();
                var entities = faker.Generate(5);
                await context.Users.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }

            if (!context.SkillsDetails.Any())
            {
                var faker = new Faker<User>();
                var entities = faker.Generate(5);
                await context.Users.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }
    }
}
