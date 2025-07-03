
namespace ProyectAntivirusBackend.DTOs;
public class LocalityDTO
{
    public int Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
