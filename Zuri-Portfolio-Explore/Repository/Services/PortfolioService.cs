using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.DTOs.Request;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Repository.Interfaces;

namespace Zuri_Portfolio_Explore.Repository.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly AppDbContext _context;
        public PortfolioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<List<PortfolioResponse>>> GetAllPortfolios()
        {
            List<PortfolioResponse> portfolioResponses = new();
            try
            {

                // Retrieve user items from DB
                var users = await _context.Users.Include(u => u.SkillDetails).Include(u => u.Projects).ToListAsync();

                if (users.Count() == 0)
                {
                    return ApiResponse<List<PortfolioResponse>>.Success("No items to be retrieved", portfolioResponses);
                }

                foreach (var item in users)
                {
                    var portfolioResponse = new PortfolioResponse()
                    {
                        ProfileUrl = item.ProfilePicture,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Address = item.Location == string.Empty && item.Country == string.Empty
                            ? " "
                            : string.Concat(item.Location, ", ", item.Country),
                        Provider = item.Provider,
                        Location = item.Location,
                        Track = item.Track,
                        Ranking = item.Ranking,
                        Tag = item.Tag,
                        Skills = item.SkillDetails.Select(m => m.Skills).ToList(), //Gets user skills
                        Projects = item.Projects.Select(m => m.Id).ToList().Count //Gets user total project
                    };

                    portfolioResponses.Add(portfolioResponse);
                }

                return ApiResponse<List<PortfolioResponse>>.Success("Items retireved successfully", portfolioResponses);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResponse<List<PortfolioResponse>>.Fail("Failed to retrieve items", 500);
            }
        }
        public async Task<ApiResponse<List<PortfolioResponse>>> GetByFilterPortfolios(PortfolioFilterDTO portfolioFilterDTO)
        {
            var query = _context.Users
                .Include(x => x.UserRoles)
                .Include(x => x.SkillDetails)
                .Include(x => x.Projects)
                .AsQueryable(); // Start with IQueryable

            if (portfolioFilterDTO.Skill is not null)
            {
                var skillLower = portfolioFilterDTO.Skill.Trim().ToLower();
                query = query.Where(x => x.SkillDetails.Any(s => s.Skills.ToLower() == skillLower));
            }
            if (portfolioFilterDTO.Country is not null)
            {
                var countryLower = portfolioFilterDTO.Country.Trim().ToLower();
                query = query.Where(x => x.Country.Trim().ToLower() == countryLower);
            }
            if (portfolioFilterDTO.Track is not null)
            {
                var trackLower = portfolioFilterDTO.Track.Trim().ToLower();
                query = query.Where(x => x.Track.ToLower() == trackLower);
            }
            if (portfolioFilterDTO.Ranking is not null)
            {
                var rankingLower = portfolioFilterDTO.Ranking.Trim().ToLower();
                query = query.Where(x => x.Ranking.ToLower() == rankingLower);
            }
            if (portfolioFilterDTO.Tag is not null)
            {
                var tagLower = portfolioFilterDTO.Tag.Trim().ToLower();
                query = query.Where(x => x.Tag != null && x.Tag.ToLower() == tagLower);
            }
            if (portfolioFilterDTO.Location is not null)
            {
                var locationLower = portfolioFilterDTO.Location.Trim().ToLower();
                query = query.Where(x => x.Location.ToLower() == locationLower);
            }
            if (portfolioFilterDTO.Provider is not null)
            {
                var providerLower = portfolioFilterDTO.Provider.Trim().ToLower();
                query = query.Where(x => x.Provider.ToLower() == providerLower);
            }
            if (portfolioFilterDTO.RoleId is not null)
            {
                query = query.Where(x => x.UserRoles != null && x.UserRoles.RoleId == portfolioFilterDTO.RoleId);
            }

            if (portfolioFilterDTO.CreatedAtMin != null)
            {
                query = query.Where(x => x.CreatedAt >= portfolioFilterDTO.CreatedAtMin);
            }

            if (portfolioFilterDTO.CreatedAtMax != null)
            {
                query = query.Where(x => x.CreatedAt <= portfolioFilterDTO.CreatedAtMax);
            }
            int pageSize = portfolioFilterDTO.PageSize ?? 10; // Default page size, you can change it
            int pageNumber = portfolioFilterDTO.PageNumber ?? 1; // Default page number, you can change it
            int itemsToSkip = (pageNumber - 1) * pageSize;// Calculate the number of items to skip

            query = query.Skip(itemsToSkip).Take(pageSize);
            
            switch (portfolioFilterDTO.SortBy)
            {
                case SortBy.Newest:
                    query = query.OrderByDescending(x => x.CreatedAt);
                    break;
                case SortBy.Oldest:
                    query = query.OrderBy(x => x.CreatedAt);
                    break;
                default:
                    break;
            }

            // Apply pagination

            var portfolioResponses = await query
                .Select(item => new PortfolioResponse()
                {
                    ProfileUrl = item.ProfilePicture,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Address = item.Location == string.Empty && item.Country == string.Empty
                            ? " "
                            : string.Concat(item.Location, ", ", item.Country),
                    Provider = item.Provider,
                    Location = item.Location,
                    Track = item.Track,
                    Ranking = item.Ranking,
                    Tag = item.Tag,
                    CreatedAt = item.CreatedAt,
                    Skills = item.SkillDetails.Select(m => m.Skills).ToList(), //Gets user skills
                    Projects = item.Projects.Select(m => m.Id).ToList().Count //Gets user total project
                })
                .ToListAsync(); // Execute the query and retrieve the results

            return ApiResponse<List<PortfolioResponse>>.Success("Items retrieved successfully", portfolioResponses);
        }

        public async Task<ApiResponse<List<PortfolioResponse>>> GetPortfoliosBySearchTerm(string searchTerm)
        {
            try
            {

                // Retrieve user items from DB
                searchTerm = searchTerm.ToLower();
                var portfolioResponses = await _context.Users
                    .Include(u => u.SkillDetails)
                    .Include(u => u.Projects)
                    .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Where(x => x.FirstName.ToLower().Contains(searchTerm) || x.LastName.ToLower().Contains(searchTerm)
                    || x.Username.ToLower().Contains(searchTerm) || x.UserRoles.Role.Name.ToLower().Contains(searchTerm))
                    .Select(x => new PortfolioResponse()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Provider = x.Provider,
                        Skills = x.SkillDetails.Select(m => m.Skills).ToList(), //Gets user skills
                        Projects = x.Projects.Select(m => m.Id).ToList().Count //Gets user total project
                    })
                    .ToListAsync();

                if (portfolioResponses.Count() == 0)
                {
                    return ApiResponse<List<PortfolioResponse>>.Success("No items to be retrieved", portfolioResponses);
                }
                return ApiResponse<List<PortfolioResponse>>.Success("Items retireved successfully", portfolioResponses);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResponse<List<PortfolioResponse>>.Fail("Failed to retrieve items", 500);
            }
        }
    }
}
