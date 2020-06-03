using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutosQuery : IRequest<IEnumerable<Produto>>
    {
        public GetProdutosQuery(Produto produto, IUserRef userRef)
        {
            this.Filters = produto;
        }

        public Produto Filters { get; }
    }
}
