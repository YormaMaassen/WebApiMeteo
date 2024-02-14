using AutoMapper;
using WebApiMeteo.Entities;

namespace WebApiMeteo
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Meteo, Model.Meteo>()
                .ReverseMap();
            CreateMap<Ville, Model.Ville>()
                .ReverseMap();
        }
    }
}
