using AutoMapper;
using Models.Domain;
using Models.Dto;

namespace Vega.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelDto>().ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
