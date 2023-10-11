using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Zuri_Portfolio_Explore.Domains.DTOs.Request
{
    public class PortfolioDTO
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Provider { get; set; }
        public List<string> Skills { get; set; }
        public List<ProjectDTO> Projects { get; set; }
    }
    /// <summary>
    /// Specifies the sorting options.
    /// </summary>
    public enum SortBy
    {
        /// <summary>
        /// Sort by newest first.
        /// </summary>
        [Display(Name = "Newest")]
        [EnumMember(Value = "newest")]
        Newest = 1,

        /// <summary>
        /// Sort by oldest first.
        /// </summary>
        [Display(Name = "Oldest")]
        [EnumMember(Value = "oldest")]
        Oldest = 2
    }
    public class PortfolioFilterDTO
    {
        public SortBy SortBy { get; set; } = SortBy.Newest;
        public string? Location { get; set; }
        public DateTime? CreatedAtMin { get; set; }
        public DateTime? CreatedAtMax { get; set; }
        public string? Country { get; set; }
        public string? Provider { get; set; }
        public string? Skill { get; set; }
        public string? Track { get; set; }
        public string? Ranking { get; set; }
        public int? RoleId { get; set; }
        public string? Tag { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber  { get; set; }
    }
}
