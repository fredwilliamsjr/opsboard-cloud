namespace OpsBoard.Api.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Severity { get; set; } = "Medium";
        public string Status { get; set; } = "Open";
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ServiceItemId { get; set; }
        public ServiceItem? ServiceItem { get; set; }
    }
}