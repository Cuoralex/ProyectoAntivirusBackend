namespace ProyectAntivirusBackend.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsActive { get; set; }
    }
}