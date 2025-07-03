namespace ProyectAntivirusBackend.DTOs
{
    public class UpdateUserDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Role { get; set; } = "user";
        public DateTime Birthdate { get; set; }
    }
}