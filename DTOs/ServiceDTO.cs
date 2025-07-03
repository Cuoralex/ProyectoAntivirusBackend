public class ServiceDTO
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public int ServiceTypeId { get; set; }
    public string ServiceTypeName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}
