namespace ProyectAntivirusBackend.DTOs
{
public class CreateRatingDTO
{
    public int Score { get; set; }
    public required string Comment { get; set; }
}
}