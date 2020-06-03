using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using JsDesenvolvimento.Data.Repository.Impl;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IRequest<>).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequest<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(IRequestHandler<>).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(IRequestHandler<,>).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(this.ThisAssembly)
            //       .AsClosedTypesOf(typeof(IRequest<>))
            //       .AsImplementedInterfaces()
            //       .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(this.ThisAssembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>))
            //    .AsClosedTypesOf(typeof(IRequestHandler<>))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
        }
    }
}
