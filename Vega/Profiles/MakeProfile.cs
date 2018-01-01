using AutoMapper;
using Models.Domain;
using Models.Dto;

namespace Vega.Profiles
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<Make, MakeDto>().ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
