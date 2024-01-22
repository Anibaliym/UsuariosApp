using AutoMapper;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Commands.Usuario.Commands;

namespace Usuarios.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() {

            #region Usuario

            CreateMap<UsuarioCrearViewModel, UsuarioCrearCommand>().ConstructUsing(item => new UsuarioCrearCommand(
                item.IdPersona, 
                item.Nick,
                item.Tipo,
                item.Estado
            ));

            CreateMap<UsuarioViewModel, UsuarioModificarCommand>().ConstructUsing(item => new UsuarioModificarCommand(
                item.Id,
                item.IdPersona,
                item.Nick,
                item.Tipo,
                item.Estado
            ));

            #endregion

        }

    }
}
