using Microsoft.EntityFrameworkCore;
using Zuri_Portfolio_Explore.Data;
using Zuri_Portfolio_Explore.Domains.DTOs.Request;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Domains.Filter;
using Zuri_Portfolio_Explore.Domains.Models;
using Zuri_Portfolio_Explore.Repository.Interfaces;
using Zuri_Portfolio_Explore.Utilities;

namespace Zuri_Portfolio_Explore.Repository.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUriService _uriService;
        public PortfolioService(AppDbContext context, IHttpContextAccessor httpContextAccessor, IUriService uriService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _uriService = uriService;
        }

        public async Task<ApiResponse<List<PortfolioResponse>>> GetAllPortfolios(PaginationFilter validFilter)
        {
            List<PortfolioResponse> portfolioResponses = new();
            var route = _httpContextAccessor.HttpContext.Request.Path.Value;

            // Retrieve user items from DB
            var usersQuery = _context.Users.Include(u => u.SkillDetails).Include(u => u.Projects).Include(u => u.UserTrack)
                .ThenInclude(u => u.Track);

            var users = await usersQuery
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                 .Take(validFilter.PageSize)
                .ToListAsync();
            var usersCount = usersQuery.Count();
            if (users.Count() == 0)
            {
                return ApiResponse<List<PortfolioResponse>>.Success("No items to be retrieved", portfolioResponses);
            }

            foreach (var item in users)
            {
                var portfolioResponse = MapToResponse(item);
                portfolioResponses.Add(portfolioResponse);
            }

            return PaginationHelper.CreatePagedReponse(portfolioResponses, validFilter, usersCount, _uriService, route, "Items retrieved successfully");


        }
        public async Task<ApiResponse<List<PortfolioResponse>>> GetByFilterPortfolios(PortfolioFilterDTO portfolioFilterDTO, PaginationFilter validFilter)
        {
            var route = _httpContextAccessor.HttpContext.Request.Path.Value;

            var query = _context.Users
            // .Include(x => x.UserRoles)
            .Include(x => x.SkillDetails)
            .Include(x => x.Projects)
            .Include(u => u.UserTrack)
                .ThenInclude(u => u.Track)
            .AsQueryable(); // Start with IQueryable

            if (portfolioFilterDTO.Skill is not null)
            {
                var skillLower = portfolioFilterDTO.Skill.Trim().ToLower();
                query = query.Where(x => x.SkillDetails.Any(s => s.Skills.ToLower() == skillLower));
            }
            if (portfolioFilterDTO.Country is not null)
            {
                var countryLower = portfolioFilterDTO.Country.Trim().ToLower();
                query = query.Where(x => x.Country.Trim().ToLower() == countryLower);
            }
            if (portfolioFilterDTO.Track is not null)
            {
                var trackLower = portfolioFilterDTO.Track.Trim().ToLower();
                query = query.Where(x => x.UserTrack.Any(x => x.Track.track.ToLower() == trackLower));
            }

            //if (portfolioFilterDTO.Ranking is not null)
            //{
            //    var rankingLower = portfolioFilterDTO.Ranking.Trim().ToLower();
            //    query = query.Where(x => x.Ranking.ToLower() == rankingLower);
            //}
            //if (portfolioFilterDTO.Tag is not null)
            //{
            //    var tagLower = portfolioFilterDTO.Tag.Trim().ToLower();
            //    query = query.Where(x => x.Tag != null && x.Tag.ToLower() == tagLower);
            //}
            if (portfolioFilterDTO.Location is not null)
            {
                var locations = portfolioFilterDTO.Location.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (locations.Length > 1)
                {
                    var filterlocations = locations.Select(x => x.ToLower()).ToList();
                    query = query.Where(x => filterlocations.Contains(x.Location.ToLower()) || filterlocations.Contains(x.Country.ToLower()));
                }
                else
                {
                    query = query.Where(x => x.Location.ToLower() == portfolioFilterDTO.Location.ToLower());
                }
            }
            if (portfolioFilterDTO.Provider is not null)
            {
                var providerLower = portfolioFilterDTO.Provider.Trim().ToLower();
                query = query.Where(x => x.Provider.ToLower() == providerLower);
            }
            //if (portfolioFilterDTO.RoleId is not null)
            //{
            //    query = query.Where(x => x.UserRoles != null && x.UserRoles.RoleId == portfolioFilterDTO.RoleId);
            //}

            if (portfolioFilterDTO.CreatedAtMin != null)
            {
                query = query.Where(x => x.CreatedAt >= portfolioFilterDTO.CreatedAtMin);
            }

            if (portfolioFilterDTO.CreatedAtMax != null)
            {
                query = query.Where(x => x.CreatedAt <= portfolioFilterDTO.CreatedAtMax);
            }
            //int pageSize = portfolioFilterDTO.PageSize ?? 10; // Default page size, you can change it
            //int pageNumber = portfolioFilterDTO.PageNumber ?? 1; // Default page number, you can change it
            //int itemsToSkip = (pageNumber - 1) * pageSize;// Calculate the number of items to skip

            //query = query.Skip(itemsToSkip).Take(pageSize);

            switch (portfolioFilterDTO.SortBy)
            {
                case SortBy.Newest:
                    query = query.OrderByDescending(x => x.CreatedAt);
                    break;
                case SortBy.Oldest:
                    query = query.OrderBy(x => x.CreatedAt);
                    break;
                default:
                    break;
            }
            // Apply pagination
            var queryCount = await query.CountAsync();
            query = query
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                 .Take(validFilter.PageSize);

            var portfolioResponses = await query
                .Select(item => MapToResponse(item))
                .ToListAsync(); // Execute the query and retrieve the results

            if (!portfolioResponses.Any())
            {
                return ApiResponse<List<PortfolioResponse>>.Success("Nothing matched your search", portfolioResponses);
            }

            return PaginationHelper.CreatePagedReponse(portfolioResponses, validFilter, queryCount, _uriService, route, "Items retrieved successfully");
        }
        public async Task<ApiResponse<List<PortfolioResponse>>> GetPortfoliosBySearchTerm(string searchTerm, PaginationFilter validFilter)
        {
            var route = _httpContextAccessor.HttpContext.Request.Path.Value;
            // Retrieve user items from DB
            searchTerm = searchTerm.ToLower();
            var portfolioResponseQuery = _context.Users
                .Include(u => u.SkillDetails)
                .Include(u => u.Projects)
                .Include(u => u.UserTrack)
                .ThenInclude(u => u.Track)
                //.Include(u => u.UserRoles)
                //.ThenInclude(x => x.Role)
                .Where(x => x.FirstName.ToLower().Contains(searchTerm) || x.LastName.ToLower().Contains(searchTerm)
                || x.Username.ToLower().Contains(searchTerm))
                .Select(x => MapToResponse(x));
            //|| x.UserTrack.Any(x => x.Track.track.ToLower().Contains(searchTerm))
            var portfolioResponses = await portfolioResponseQuery
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                 .Take(validFilter.PageSize)
                .ToListAsync();
            var portfolioCount = await portfolioResponseQuery.CountAsync();
            if (!portfolioResponses.Any())
            {
                return ApiResponse<List<PortfolioResponse>>.Success("No items to be retrieved", portfolioResponses);
            }
            return PaginationHelper.CreatePagedReponse(portfolioResponses, validFilter, portfolioCount, _uriService, route, "Items retrieved successfully");
        }

        public async Task<ApiResponse<PortfolioResponse>> GetPortfolioByUserId(Guid userId)
        {
            var portfolio = await _context.Users
                .Include(u => u.SkillDetails)
                .Include(u => u.Projects)
                .Include(u => u.UserTrack)
                .ThenInclude(u => u.Track)
                // .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (portfolio == default)
                return ApiResponse<PortfolioResponse>.Fail("User not found", 404);
            var userPortfolio = MapToResponse(portfolio);
            return ApiResponse<PortfolioResponse>.Success("Portfolio Retrieved", userPortfolio);
        }

        private static PortfolioResponse MapToResponse(User item)
        {
            return new PortfolioResponse()
            {
                Id = item.Id.ToString(),
                ProfilePictureUrl = item.ProfilePicture,
                ProfileUrl = Shared.ProfileUrl(item.Id),
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Location == string.Empty && item.Country == string.Empty
                        ? " "
                        : string.Concat(item.Location, ", ", item.Country),
                Provider = item.Provider,
                Location = item.Location,
                Track = item.UserTrack.Select(x => x.Track.track).ToList(),
                //Ranking = item.Ranking,
                //Tag = item.Tag,
                Skills = item.SkillDetails.Select(m => m.Skills).ToList(), //Gets user skills
                Projects = item.Projects.Select(m => m.Id).ToList().Count, //Gets user total project
                CreatedAt = item.CreatedAt,
                Country = item.Country
            };
        }
    }
}