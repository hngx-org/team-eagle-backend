using Zuri_Portfolio_Explore.Domains.DTOs;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDTO>> GetPortfolios(); //Not needed. => TODO:: To be removed by Adesina
        Task<ApiResponse<List<PortfolioResponse>>> GetAllPortfolios();
    }
}
