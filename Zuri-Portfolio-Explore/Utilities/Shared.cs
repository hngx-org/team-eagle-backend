namespace Zuri_Portfolio_Explore.Utilities
{
    public static class Shared
    {
        private readonly static HttpContextAccessor _httpContextAccessor = new();

        public static string ProfileUrl(Guid userId)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/api/explore/getPortfolio/{userId.ToString()}";
            //var baseUrl = $"https://zuriportfolio-frontend-pw1h-1fxrnqen1-zuri-frontend.vercel.app/portfolio/{userId}";
            return baseUrl;
        }


    }
}
