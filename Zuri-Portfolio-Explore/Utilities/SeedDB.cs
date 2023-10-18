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
					.RuleFor(u => u.ProfilePicture, f => "")
					.RuleFor(u => u.Password, f => f.Name.FirstName())
					.RuleFor(u => u.RefreshToken, f => f.Name.FirstName())
					.RuleFor(u => u.Location, f => new List<string> { "Kaduna", "Lagos", "Abuja", "Uyo", "Jos" }[f.Random.Number(0, 4)])
					.RuleFor(u => u.Country, f => "Nigeria")
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
					.RuleFor(u => u.SectionId, f => f.Random.Number(1, 5))
					.RuleFor(u => u.User, f => userfaker.Generate());

				var socialUsersFaker = new Faker<SocialUser>()
					.RuleFor(u => u.SocialMedia, f => socialfaker.Generate())
					.RuleFor(u => u.SocialMediaId, f => f.Random.Number(1, 5))
					.RuleFor(u => u.Url, f => f.Internet.Url())
					.RuleFor(u => u.UserId, f => f.Random.Guid())
					.RuleFor(u => u.User, f => userfaker.Generate());

				var rolefaker = new Faker<Role>()
					.RuleFor(u => u.Name, f => f.Name.Suffix());

				var userRolesFaker = new Faker<UserRoles>()
					.RuleFor(u => u.RoleId, f => f.Random.Number(1, 5))
					.RuleFor(u => u.UserId, f => f.Random.Guid())
					.RuleFor(u => u.User, f => userfaker.Generate())
					.RuleFor(u => u.Role, f => rolefaker.Generate());

				var skills = skillfaker.Generate(5);
				var userRoles = userRolesFaker.Generate(5);
				var socialUsersFakers = socialUsersFaker.Generate(5);
				context.SkillsDetails.AddRange(skills);
				context.SocialUsers.AddRange(socialUsersFakers);
				context.UserRoles.AddRange(userRoles);
				context.SaveChanges();
			}
		}

		public static void SeedSharedDb(AppDbContext context, bool seedData)
		{
			bool areYouSureYouWantToSeed = false;
			if (seedData && areYouSureYouWantToSeed)
			{
				var webTracks = new List<string> { "Web Development", "Front-end Development", "Back-end Development", "Full-stack Development" };
				var iotTracks = new List<string> { "Internet of Things (IoT)", "Embedded Systems" };
				var images = General.images;
				var webSkills = General.webDeveloperSkills;
				var embededIot = General.embededIot;
				var graphicsDesignerSkills = General.graphicsDesignerSkills;
				var artificialIntelligenceSkills = General.artificialIntelligenceSkills;
				var mobileAppDevelopmentSkills = General.mobileAppDevelopmentSkills;
				var blockchainDevelopmentSkills = General.blockchainDevelopmentSkills;
				var cybersecuritySkills = General.cybersecuritySkills;
				var dataScienceSkills = General.dataScienceSkills;
				var usersTracks = new List<UserTrack>();
				var usersSkills = new List<SkillsDetail>();

				var tracks = context.Tracks.ToList();
				var users = context.Users.ToList();

				for (int i = 0; i < users.Count; i++)
				{
					Random random = new Random();
					int randomTrack = random.Next(0, tracks.Count);
					int randomImage = random.Next(0, images.Count);
					var user = users[i];
					var track = tracks[randomTrack];
					var userSkills = new List<string>();
					var trackModel = new UserTrack()
					{
						TrackId = track.Id,
						UserId = user.Id
					};
					if (webTracks.Contains(track.track))
					{
						userSkills = webSkills;
					}
					else
					{
						if (iotTracks.Contains(track.track))
						{
							userSkills = embededIot;
						}
						else if (track.track == "UI/UX Design" || track.track == "Graphics Designer")
						{
							userSkills = graphicsDesignerSkills;
						}
						else if (track.track == "Machine Learning" || track.track == "Artificial Intelligence")
						{
							userSkills = artificialIntelligenceSkills;
						}
						else if (track.track == "Data Science")
						{
							userSkills = dataScienceSkills;
						}
						else if (track.track == "Mobile App Development")
						{
							userSkills = mobileAppDevelopmentSkills;
						}
						else if (track.track == "DevOps" || track.track == "Cybersecurity" || track.track == "Cloud Computing")
						{
							userSkills = cybersecuritySkills;
						}
						else if (track.track == "Blockchain Development")
						{
							userSkills = blockchainDevelopmentSkills;
						}
					}
					var skills = userSkills.Select(x => new SkillsDetail()
					{
						UserId = user.Id,
						Skills = x,
						SectionId = 3
					}).ToList();
					usersSkills.AddRange(skills);
					user.ProfilePicture = images[randomImage];
					user.CreatedAt = DateTime.UtcNow;
					context.Update(users[i]);
					usersTracks.Add(trackModel);
				}
				context.AddRange(usersTracks);
				if (usersSkills.Count > 500)
				{
					var chunk = usersSkills.Chunk(500);
					foreach (var item in chunk)
					{
						context.AddRange(item);
					}
				}
				else
				{
					context.AddRange(usersSkills);
				}
				context.SaveChanges();
			}	
        }
	}
}
