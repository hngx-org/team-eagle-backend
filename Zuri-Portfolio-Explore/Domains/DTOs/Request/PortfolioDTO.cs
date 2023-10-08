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
}
