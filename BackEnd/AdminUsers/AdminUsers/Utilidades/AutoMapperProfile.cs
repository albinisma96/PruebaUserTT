
using AutoMapper;
using AdminUsers.DTOs;
using AdminUsers.Models;
using System.Globalization;

namespace AdminUsers.Utilidades
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            //CreateMap<Usuario, UsuarioDTO>().ForMember(destino => destino.id,opt=> opt.MapFrom(origen => origen.idDepartamento.nombre))
            //    .ForMember(destino => destino.nombreCargo, opt => opt.MapFrom(origen => origen.idCargo.nombre));
            //CreateMap<UsuarioDTO, Usuario>().ForMember(destino => destino.idDepartamento, opt => opt.Ignore()).ForMember(destino => destino.idCargo, opt => opt.Ignore());
        }

    }
}
