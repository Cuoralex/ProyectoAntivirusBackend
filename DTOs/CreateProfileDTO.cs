namespace ProyectAntivirusBackend.DTOs
{
    public class CreateProfileDTO
    {
        public int UserId { get; set; }
        public string Preferences { get; set; } = "{}";
        public string Biography { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
    }
}