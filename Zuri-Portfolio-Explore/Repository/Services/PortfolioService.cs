using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.DTOs;
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
            try{

                // Retrieve user items from DB

                var users = await _context.Users.Include(u => u.SkillDetails).Include(u => u.Projects).ToListAsync();

                if(users.Count == 0)
                {
                    return ApiResponse<List<PortfolioResponse>>.Success("No items to be retrieved", portfolioResponses);
                }
                
                foreach(var item in users)
                {
                    var portfolioResponse = new PortfolioResponse()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Provider = item.Provider,
                        Skills = item.SkillDetails.Select(m => m.Skills).ToList(), //Gets user skills
                        Projects = item.Projects.Select(m => m.Id).ToList().Count //Gets user total project
                    };

                    portfolioResponses.Add(portfolioResponse);
                }

                return ApiResponse<List<PortfolioResponse>>.Success("Items retireved successfully", portfolioResponses);

                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResponse<List<PortfolioResponse>>.Fail("Failed to retrieve items", 500);
            }
        }

        public async Task<List<PortfolioDTO>> GetPortfolios()
        {
            var users = await _context.Users.ToListAsync();
            var portfolios = users.Select(x => new PortfolioDTO()
            {
                Name = x.FirstName + " " + x.LastName,
                Provider = x.Provider

            }).ToList();
            return portfolios;
        }
    }
}
