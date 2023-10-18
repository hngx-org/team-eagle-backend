using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Repository.Interfaces;

namespace Zuri_Portfolio_Explore.Repository.Services
{
	public class TrackService : ITrackService
	{
		private readonly AppDbContext _context;

		public TrackService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResponse<List<TrackResposne>>> GetTracks()
		{
			var tracks = await _context.Tracks.ToListAsync();
			var response = tracks.Select(x => new TrackResposne()
			{
				 Id = x.Id,	
				 Name = x.track,
			}).ToList();
			return ApiResponse<List<TrackResposne>>.Success("success", response);
		}
	}
}
