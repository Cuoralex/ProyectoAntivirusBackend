using AutoMapper;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;

namespace ProyectAntivirusBackend.Profiles
{
    public class OpportunityProfile : AutoMapper.Profile
    {
        public OpportunityProfile()
        {
            CreateMap<Opportunity, OpportunityDTO>()
                .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.SectorId))
                .ForMember(dest => dest.SectorName, opt => opt.MapFrom(src => src.Sectors.Name))
                .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.InstitutionId))
                .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.Institutions.Name))
                .ForMember(dest => dest.InstitutionImage, opt => opt.MapFrom(src => src.Institutions.Image))
                .ForMember(dest => dest.InstitutionLink, opt => opt.MapFrom(src => src.Institutions.Link))
                .ForMember(dest => dest.OpportunityTypeId, opt => opt.MapFrom(src => src.OpportunityTypeId))
                .ForMember(dest => dest.OpportunityTypeName, opt => opt.MapFrom(src => src.OpportunityTypes.Name))
                .ForMember(dest => dest.LocalityId, opt => opt.MapFrom(src => src.LocalityId))
                .ForMember(dest => dest.LocalityCity, opt => opt.MapFrom(src => src.Localities.City))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.OpportunityTypes.Categories.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.OpportunityTypes.Categories.Name));

            CreateMap<CreateOpportunityDTO, Opportunity>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Requirements, opt => opt.MapFrom(src => src.Requirements))
                .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.SectorId))
                .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.InstitutionId))
                .ForMember(dest => dest.OpportunityTypeId, opt => opt.MapFrom(src => src.OpportunityTypeId))
                .ForMember(dest => dest.LocalityId, opt => opt.MapFrom(src => src.LocalityId));
        }
    }
}
