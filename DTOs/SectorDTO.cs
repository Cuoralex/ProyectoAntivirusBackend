namespace ProyectAntivirusBackend.DTOs
{
    public class SectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CreateSectorDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}