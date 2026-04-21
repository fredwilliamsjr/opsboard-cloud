using System.ComponentModel.DataAnnotations;

namespace OpsBoard.Api.DTOs
{
    public class CreateServiceDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string OwnerTeam { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Environment { get; set; } = "dev";

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Healthy";
    }
}
