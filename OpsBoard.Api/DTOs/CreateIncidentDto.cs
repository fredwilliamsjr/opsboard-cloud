using System.ComponentModel.DataAnnotations;

namespace OpsBoard.Api.DTOs
{
    public class CreateIncidentDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Severity { get; set; } = "Medium";

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Open";

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int ServiceItemId { get; set; }
    }
}