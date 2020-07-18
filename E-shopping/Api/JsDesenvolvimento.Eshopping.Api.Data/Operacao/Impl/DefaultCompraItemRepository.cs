using JsDesenvolvimento.Data.Repository.Impl;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.Impl
{
    public class DefaultCompraItemRepository : AbstractDefaultRepository<DBModel.CompraItem>, ICompraItemRepository
    {
        public Task<IList<CompraPessoa>> GetComprasPessoa(Operacao.DBModel.Compra compra, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<CompraPessoa>>(() =>
            {
                string sql = $@"select cmp.idpessoa {nameof(CompraPessoa.idpessoa)}
		                                ,item.idcompra {nameof(CompraPessoa.idcompra)}
		                                ,prd.idproduto {nameof(CompraPessoa.idproduto)}
		                                ,item.quantidade {nameof(CompraPessoa.quantidade)}
		                                ,item.valorunitario {nameof(CompraPessoa.valorunitario)}
		                                ,prd.nome {nameof(CompraPessoa.nome)}
                                        ,prd.descricao {nameof(CompraPessoa.descricao)}
                                        ,cmp.datacompra {nameof(CompraPessoa.datacompra)}
                                        , (SELECT img.caminhodiretorio
         	                                FROM produto_imagem img
                                           WHERE img.idproduto = prd.idproduto
                                             AND img.idloja = prd.idloja
                                             AND img.idpropietario = prd.idpropietario
         	                                 AND img.imagemprincipal = 'S'
                                             AND img.situacao = 'A') {nameof(CompraPessoa.imagem)}
                                        ,CASE WHEN cmp.situacao = 'P' THEN 'Aguardando Pagamento'
                                        WHEN cmp.situacao = 'C' THEN 'Confirmado'
                                        WHEN cmp.situacao = 'F' THEN 'Saiu para Entrega'
                                        ELSE '' END {nameof(CompraPessoa.sitcompra)}
                                  from compra_item item
                                  join compra cmp
                                    on cmp.idcompra = item.idcompra
                                   and cmp.idloja = item.idloja
                                   and cmp.idpropietario = item.idpropietario
                                  join produto prd
                                    on prd.idproduto = item.idproduto
                                   and prd.idloja = item.idloja
                                   and prd.idpropietario = item.idpropietario
                                 where cmp.idpessoa = :prm_idpessoa
                                   and cmp.idpropietario = :prm_idpropietario
                                   and cmp.idloja = :prm_idloja
                                   and cmp.situacao IN ('P','C')";
                
                return this.AttachedContext.InnerConnection.Query<CompraPessoa>(sql,
                                                                    param: new
                                                                    {
                                                                        prm_idpessoa = compra.idpessoa,
                                                                        prm_idpropietario = compra.idpropietario,
                                                                        prm_idloja = compra.idloja
                                                                    },
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }
    }
}
