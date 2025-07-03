using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;

public class LocalityProfile : AutoMapper.Profile
{
    public LocalityProfile()
    {
        CreateMap<Locality, LocalityDTO>().ReverseMap();
    }
}
