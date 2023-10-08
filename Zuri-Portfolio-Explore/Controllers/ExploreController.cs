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

        ///<summary>
        /// Get all User's Portfolio 
        ///</summary>
        ///<returns> Returns a list of user's Portfolio </returns>
        [HttpGet("GetAllPortfolio")]
        public async Task<IActionResult> GetAllPortfolio()
        {
            return Ok(await _portfolioService.GetAllPortfolios());
        }

        ///<summary>
        /// Searching through User's Portfolio 
        ///</summary>
        /// <param name="searchTerm">The parameter to search with</param>
        ///<returns> Returns a list of user's Portfolio based on the search term </returns>
        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> GetAllPortfolioBySearchTerm(string searchTerm)
        {
            return Ok(await _portfolioService.GetPortfoliosBySearchTerm(searchTerm));
        }
    }
}