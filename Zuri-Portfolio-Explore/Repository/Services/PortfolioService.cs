using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.DTOs;
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
