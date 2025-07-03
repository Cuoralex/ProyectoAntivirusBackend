namespace ProyectAntivirusBackend.DTOs
{
    public class ServiceTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<ServiceDTO> Services { get; set; } = new List<ServiceDTO>();
    }
}
