namespace OpsBoard.Api.Entities
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OwnerTeam { get; set; } = string.Empty;

        public string Environment { get; set; } = "dev";

        public string Status { get; set; } = "Healthy";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
