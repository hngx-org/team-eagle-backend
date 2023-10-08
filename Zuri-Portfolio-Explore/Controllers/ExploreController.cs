using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("GetAllPortfolio")]
        public async Task<IActionResult> GetAllPortfolio()
        {
            return Ok(await _portfolioService.GetAllPortfolios());
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> GetAllPortfolioBySearchTerm(string searchTerm)
        {
            return Ok(await _portfolioService.GetPortfoliosBySearchTerm(searchTerm));
        }
    }
}