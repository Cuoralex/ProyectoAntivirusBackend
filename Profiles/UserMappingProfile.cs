using AutoMapper;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;

public class UserMappingProfile : AutoMapper.Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<UpdateUserDTO, User>();
        CreateMap<User, UserDTO>();
    }
}
