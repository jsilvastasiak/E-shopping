using DapperExtensions;
using DapperExtensions.Sql;
using JsDesenvolvimento.Data.Repository.Impl;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.Impl
{
    public class DefaultProdutoRepository : AbstractDefaultRepository<DBModel.Produto>, IProdutoRepository
    {
        private readonly ISqlGenerator SqlGenerator;

        public DefaultProdutoRepository(ISqlGenerator sqlGenerator)
        {
            this.SqlGenerator = sqlGenerator;
        }

        public override Task<IList<Produto>> Fetch(IPredicate predicate, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<Produto>>(() =>
            {
                string sql = $@"SELECT prod.idproduto
	                                    ,prod.idloja
                                        ,prod.idpropietario
                                        ,prod.idcategoria
                                        ,prod.nome
                                        ,prod.descricao
                                        ,prod.precounitario
                                        ,prod.situacao
                                    FROM produto prod";
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                string predicado = predicate.GetSql(this.SqlGenerator, parametros);

                return this.AttachedContext.InnerConnection.Query<Produto>(sql,
                                                                    param: null,
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }
    }
}
