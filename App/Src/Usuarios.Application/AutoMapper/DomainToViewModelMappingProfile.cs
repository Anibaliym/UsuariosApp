using AutoMapper;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Entities;

namespace Usuarios.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
