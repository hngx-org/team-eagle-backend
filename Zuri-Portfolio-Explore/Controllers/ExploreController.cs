using Microsoft.AspNetCore.Mvc;
using Zuri_Portfolio_Explore.Domains.DTOs.Request;
using Zuri_Portfolio_Explore.Domains.Filter;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Repository.Interfaces;

namespace Zuri_Portfolio_Explore.Controllers
{
    [ApiController]
    [Route("api/explore")]
    public class ExploreController : ControllerBase
    {

        private readonly IPortfolioService _portfolioService;

        public ExploreController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        private static IEnumerable<PortfolioResponse> PaginateItemResponse(ApiResponse<List<PortfolioResponse>> items, int page, int itemsPerPage)
        {
            var paginatedItems = items.Data
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);


            return paginatedItems;         
        }

        ///<summary>
        /// Get all User's Portfolio 
        ///</summary>
        ///<returns> Returns a list of user's Portfolio </returns>

        //[EnableCors("AllowAnyOrigin")]
        [HttpGet("GetAllPortfolio")]
        public async Task<IActionResult> GetAllPortfolio([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _portfolioService.GetAllPortfolios(validFilter);

            return Ok(response);
        }

        ///<summary>
        /// Searching through User's Portfolio 
        ///</summary>
        /// <param name="searchTerm">The parameter to search with</param>
        ///<returns> Returns a list of user's Portfolio based on the search term </returns>
        //[EnableCors("AllowAnyOrigin")]
        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> GetPortfoliosBySearchTerm(string searchTerm, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _portfolioService.GetPortfoliosBySearchTerm(searchTerm, validFilter);
            return Ok(response);
        }

        //[EnableCors("AllowAnyOrigin")]
        [HttpGet("filter")]
        public async Task<IActionResult> GetAllPortfolioFilter([FromQuery] PortfolioFilterDTO portfolioFilterDTO, int page = 1)
        {
            var validFilter = new PaginationFilter(portfolioFilterDTO.PageNumber ?? 0, portfolioFilterDTO.PageSize ?? 10);
            return Ok(await _portfolioService.GetByFilterPortfolios(portfolioFilterDTO, validFilter));

        }

        [HttpGet("getPortfolio/{userId}")]
        public async Task<IActionResult> GetPortfolio(Guid userId)
        {
            return Ok(await _portfolioService.GetPortfolioByUserId(userId));
        }
    }
}
