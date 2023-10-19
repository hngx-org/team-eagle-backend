using Microsoft.AspNetCore.Mvc;
using Zuri_Portfolio_Explore.Domains.DTOs.Request;
using Zuri_Portfolio_Explore.Domains.Filter;
using Zuri_Portfolio_Explore.Repository.Interfaces;
using Zuri_Portfolio_Explore.Repository.Services;

namespace Zuri_Portfolio_Explore.Controllers
{
    [ApiController]
    [Route("api/track")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;
		public TrackController(ITrackService trackService)
		{
			_trackService = trackService;
		}


		///<summary>
		/// Get all User's Portfolio 
		///</summary>
		///<returns> Returns a list of user's Portfolio </returns>

		//[EnableCors("AllowAnyOrigin")]
		[HttpGet("getAllTracks")]
		public async Task<IActionResult> GetTracks()
		{
			var response = await _trackService.GetTracks();
			return Ok(response);
		}

	}
}