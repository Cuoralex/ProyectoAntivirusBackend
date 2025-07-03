using System.ComponentModel.DataAnnotations;

namespace ProyectAntivirusBackend.DTOs
{
    public class CreateServiceDTO
    {
        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;
    }
}
