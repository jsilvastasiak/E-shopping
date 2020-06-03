using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IEnumerable<Produto>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetProdutosQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IEnumerable<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            using(var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IProdutoRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<Produto>(a => a.idpropietario, Operator.Eq, request.Filters.idpropietario)
                    , Predicates.Field<Produto>(a => a.idloja, Operator.Eq, request.Filters.idloja)
                    , Predicates.Field<Produto>(a => a.situacao, Operator.Eq, "A")
                );

                var produtos = repo.Fetch(filtros, cancellationToken).Result;
                return Task.FromResult<IEnumerable<Produto>>(produtos);
            }
        }
    }
}
