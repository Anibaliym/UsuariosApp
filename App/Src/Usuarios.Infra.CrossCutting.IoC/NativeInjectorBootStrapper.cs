﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Application.Interfaces;
using Usuarios.Application.Services;
using Usuarios.Domain.Commands.Usuario.Commands;
using Usuarios.Domain.Commands.Usuario.Handlers;
using Usuarios.Domain.Core.Events;
using Usuarios.Domain.Core.Mediator;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Usuario.Events;
using Usuarios.Domain.Events.Usuario.Handlers;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.CrossCutting.Bus;
using Usuarios.Infra.Data.PostgreSQL.Context;
using Usuarios.Infra.Data.PostgreSQL.EventSourcing;
using Usuarios.Infra.Data.PostgreSQL.Repository;
using Usuarios.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Usuarios.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Events

            services.AddScoped<INotificationHandler<UsuarioCrearEvent>, UsuarioCrearEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioModificarEvent>, UsuarioModificarEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioEliminarEvent>, UsuarioEliminarEventHandler>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Commands

            services.AddScoped<IRequestHandler<UsuarioCrearCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioModificarCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioEliminarCommand, CommandResponse>, UsuarioCommandHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //InfraData
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<UsuariosContext>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Infra Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}