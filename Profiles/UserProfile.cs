using AutoMapper;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;

namespace ProyectAntivirusBackend.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            // Mapeo de User a UserDTO
            CreateMap<User, UserDTO>();

            // Mapeo de CreateUserDTO a User
            CreateMap<CreateUserDTO, User>();
        }
    }
}