﻿using AutoMapper;
using Usuarios.Application.ViewModels.Log;
using Usuarios.Application.ViewModels.Seguridad;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Entities;

namespace Usuarios.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Seguridad, SeguridadViewModel>();
            CreateMap<Log, LogViewModel>();
        }
    }
}
