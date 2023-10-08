using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
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
                        Address = string.Concat(item.Location, ", ", item.Country),
                        Provider = item.Provider,
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
