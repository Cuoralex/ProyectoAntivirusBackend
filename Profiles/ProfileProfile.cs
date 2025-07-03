using AutoMapper;
using ProyectAntivirusBackend.DTOs;
using ProfileModel = ProyectAntivirusBackend.Models.Profile;

namespace ProyectAntivirusBackend.Profiles
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            // Mapeo de Profile a ProfileDTO
            CreateMap<ProfileModel, ProfileDTO>();

            // Mapeo de CreateProfileDTO a Profile
            CreateMap<CreateProfileDTO, ProfileModel>();
        }
    }
}
