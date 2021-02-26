using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using JsDesenvolvimento.Data.Repository.Impl;
using JsDesenvolvimento.Eshopping.Api.Logic.Infraestrutura;
using JsDesenvolvimento.Pagamento;
using JsDesenvolvimento.Pagamento.Impl;
using JsDesenvolvimento.Pagamento.Pagseguro.Client.Impl;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register<IPagamentoUriMapper>(c => new UriMapperPagseguro());
            builder.Register<IPagamentoConteudoEncoder>(c => new DefaultPagamentoConteudoEncoder());
            builder.Register<IPagamentoConteudoSerializer>(c => new DefaultPagamentoConteudoSerializer());
            builder.Register<IPagamentoClient>(c => new DefaultPagamentoPagseguroClient(c.Resolve<IHttpClientFactory>(), c.Resolve<IPagamentoUriMapper>(), c.Resolve<IPagamentoConteudoEncoder>(), c.Resolve<IPagamentoConteudoSerializer>())).InstancePerLifetimeScope();
        }
    }
}
