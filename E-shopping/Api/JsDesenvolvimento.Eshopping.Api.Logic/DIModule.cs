using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using JsDesenvolvimento.Data.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register<JsDesenvolvimento.Data.Repository.ILojaRepository>(ctx => new DefaultLojaRepository());
        }
    }
}
