using System.ComponentModel.DataAnnotations;

namespace OpsBoard.Api.DTOs
{
    public class UpdateServiceDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string OwnerTeam { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Environment { get; set; } = "dev";

        public string Status { get; set; } = "Healthy";




    }
}
