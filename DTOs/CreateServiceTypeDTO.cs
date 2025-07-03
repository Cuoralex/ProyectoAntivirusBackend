using System.ComponentModel.DataAnnotations;

namespace ProyectAntivirusBackend.DTOs
{
    public class CreateServiceTypeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
