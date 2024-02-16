using AutoMapper;
using Usuarios.Application.ViewModels.Log;
using Usuarios.Application.ViewModels.Seguridad;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Commands.Log.Commands;
using Usuarios.Domain.Commands.Seguridad.Commands;
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

            #region Seguridad

            CreateMap<SeguridadCrearViewModel, SeguridadCrearCommand>().ConstructUsing(item => new SeguridadCrearCommand(
                item.IdUsuario, 
                item.Contrasena
            ));

            CreateMap<SeguridadModificarViewModel, SeguridadModificarCommand>().ConstructUsing(item => new SeguridadModificarCommand(
                item.Id,
                item.IdUsuario,
                item.Contrasena,
                item.Intentos
            ));

            #endregion

            #region Log

            CreateMap<LogCrearViewModel, LogCrearCommand>().ConstructUsing(item => new LogCrearCommand(
                item.IdUsuario, item.Accion, item.Observacion
            ));

            #endregion
        }
    }
}
