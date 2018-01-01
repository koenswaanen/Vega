using AutoMapper;
using Models.Domain;
using Models.Dto;

namespace Vega.Profiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDto>().ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
