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
    public class PortfolioFilterDTO
    {
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? Provider { get; set; }
        public string? Skill { get; set; }
        public string? Track { get; set; }
        public string? Ranking { get; set; }
        public int? RoleId { get; set; }
        public string? Tag { get; set; }
    }
}
