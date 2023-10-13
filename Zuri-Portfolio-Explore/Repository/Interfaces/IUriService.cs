using Zuri_Portfolio_Explore.Domains.Filter;

namespace Zuri_Portfolio_Explore.Repository.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
