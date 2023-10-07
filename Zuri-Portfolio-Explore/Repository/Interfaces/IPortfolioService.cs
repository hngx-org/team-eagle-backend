using Zuri_Portfolio_Explore.Domains.DTOs;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDTO>> GetPortfolios();
    }
}
