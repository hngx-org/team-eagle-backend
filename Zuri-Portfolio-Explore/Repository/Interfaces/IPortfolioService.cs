using Zuri_Portfolio_Explore.Domains.DTOs.Request;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Domains.Filter;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
    public interface IPortfolioService
    {
        Task<ApiResponse<List<PortfolioResponse>>> GetAllPortfolios(PaginationFilter validFilter);
        Task<ApiResponse<List<PortfolioResponse>>> GetByFilterPortfolios(PortfolioFilterDTO portfolioFilterDTO, PaginationFilter validFilter);
        Task<ApiResponse<List<PortfolioResponse>>> GetPortfoliosBySearchTerm(string searchTerm, PaginationFilter validFilter);
        Task<ApiResponse<PortfolioResponse>> GetPortfolioByUserId(Guid userId);
    }
}
