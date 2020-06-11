using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model
{
    public class FinalizarCompraRequest
    {
        public IList<ProdutoCompradoDto> ProdutosCompra { get; set; }
        public Pessoa Comprador { get; set; }
    }
}
