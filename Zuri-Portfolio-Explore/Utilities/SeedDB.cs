using Bogus;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.Models;

namespace Zuri_Portfolio_Explore.Utilities
{
    public class SeedDB
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var socialfaker = new Faker<SocialMedia>().
                   RuleFor(u => u.Name, f => f.Name.LastName());

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

                var sectionfaker = new Faker<Section>()
                    .RuleFor(u => u.Name, f => f.Name.LastName())
                    .RuleFor(u => u.Description, f => f.Name.LastName())
                    .RuleFor(u => u.Meta, f => f.Name.LastName());
              
                var skillfaker = new Faker<SkillsDetail>()
                    .RuleFor(u => u.UserId, f => f.Random.Guid())
                    .RuleFor(u => u.Skills, f => f.Name.FirstName())
                    .RuleFor(u => u.Section, f => sectionfaker.Generate())
                    .RuleFor(u => u.SectionId, f => f.Random.Number(1,5))
                    .RuleFor(u => u.User, f => userfaker.Generate());

                var socialUsersFaker = new Faker<SocialUser>()
                    .RuleFor(u => u.SocialMedia, f => socialfaker.Generate())
                    .RuleFor(u => u.SocialMediaId, f => f.Random.Number(1, 5))
                    .RuleFor(u => u.Url, f => f.Internet.Url())
                    .RuleFor(u => u.UserId, f => f.Random.Guid())
                    .RuleFor(u => u.User, f => userfaker.Generate());

                var skills = skillfaker.Generate(5);
                var socialUsersFakers = socialUsersFaker.Generate(5);
                context.SkillsDetails.AddRange(skills);
                context.SocialUsers.AddRange(socialUsersFakers);
                context.SaveChanges();
            }
        }
    }
}
