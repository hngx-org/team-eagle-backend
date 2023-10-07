using Bogus;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.Models;

namespace Zuri_Portfolio_Explore.Utilities
{
    public class SeedDB
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.SocialMedias.Any())
            {
                var faker = new Faker<SocialMedia>().
                    RuleFor(u => u.Name, f => f.Name.LastName());
                var socials = faker.Generate(10);
                context.AddRange(socials);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var userfaker = new Faker<User>()
                    .RuleFor(u => u.Username, f => f.Name.FirstName())
                    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                    .RuleFor(u => u.LastName, f => f.Name.FirstName())
                    .RuleFor(u => u.SectionOrder, f => f.Name.FirstName())
                    .RuleFor(u => u.Provider, f => f.Name.FirstName())
                    .RuleFor(u => u.ProfilePicture, f => f.Name.FirstName())
                    .RuleFor(u => u.Password, f => f.Name.FirstName())
                    .RuleFor(u => u.RefreshToken, f => f.Name.FirstName())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName))
                    ;
                var users = userfaker.Generate(5);
                context.Users.AddRange(users);
                context.SaveChanges();


                var skillfaker = new Faker<SkillsDetail>()
                    .RuleFor(u => u.UserId, f => f.Random.Guid())
                    .RuleFor(u => u.Skills, f => f.Name.FirstName())
                   // .RuleFor(u => u.SectionId, f => f.Name.FirstName())
                    .RuleFor(u => u.User, f => userfaker.Generate());
                var skills = skillfaker.Generate(5);
                context.SkillsDetails.AddRange(skills);
                context.SaveChanges();
            }
        }
    }
}
