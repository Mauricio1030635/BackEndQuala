using AutoMapper;
using Quala.Core.Dto;
using Quala.Core.Models;


namespace Quala.Extensions
{
   public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo para NuevaEntidad
        CreateMap<NuevaEntidad, NuevaEntidadDto>()
            .ForMember(dest => dest.NombreMoneda, opt => opt.MapFrom(src => src.NuevaMoneda.NombreMoneda));

        CreateMap<NuevaEntidadCreateDto, NuevaEntidad>();
        CreateMap<NuevaEntidadUpdateDto, NuevaEntidad>();

        // Mapeo para NuevaMoneda
        CreateMap<NuevaMoneda, NuevaMonedaDto>();
        CreateMap<NuevaMonedaCreateDto, NuevaMoneda>();
        CreateMap<NuevaMonedaUpdateDto, NuevaMoneda>();
    }
}

}
