using AutoMapper;
using PortfolioAPI.Core.Models;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Utilities;
class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<UpdateCompanyDto, Company>();
        
        CreateMap<Company, CompanyDto>()
            .ForMember(companyDto => companyDto.ProjectsDto, option => option.MapFrom(company => company.Projects))
        ;
    }
}