using Zuri_Portfolio_Explore.Domains.DTOs;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
    public interface IPortfolioService
    {
        Task<ApiResponse<List<PortfolioResponse>>> GetAllPortfolios();
    }
}
