using Zuri_Portfolio_Explore.Domains.DTOs.Response;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
	public interface ITrackService
	{
		Task<ApiResponse<List<TrackResposne>>> GetTracks();
	}
}
