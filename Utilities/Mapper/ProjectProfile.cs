using AutoMapper;
using PortfolioAPI.Dtos;
using PortfolioAPI.Core.Models;

namespace PortfolioAPI.Utilities;
class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();
        
        CreateMap<Project, ProjectDto>()
            .ForMember(projectDto => projectDto.CompanyDto, option => option.MapFrom(project => project.Company))
            .ForMember(projectDto => projectDto.TechnologiesDto, option => option.MapFrom(project => project.Technologies))
        ;
    }
}