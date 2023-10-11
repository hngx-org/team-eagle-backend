using System.Text.Json;

namespace Zuri_Portfolio_Explore.Domains.ErrorModels
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public bool IsSuccessful { get; set; } = false;
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
