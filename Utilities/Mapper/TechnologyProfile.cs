using AutoMapper;
using PortfolioAPI.Core.Models;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Utilities;
class TechnologyProfile : Profile
{
    public TechnologyProfile()
    {
        CreateMap<CreateTechnologyDto, Technology>();
        CreateMap<UpdateTechnologyDto, Technology>();

        CreateMap<Technology, TechnologyDto>();
    }
}