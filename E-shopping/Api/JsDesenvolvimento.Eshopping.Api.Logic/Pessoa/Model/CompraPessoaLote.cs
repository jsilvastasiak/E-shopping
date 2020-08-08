using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model
{
    public class CompraPessoaLote
    {
        public IList<CompraPessoa> itens { get; set; }
        public string sitcompra { get; set; }
        public DateTimeOffset datacompra { get; set; }
    }
}
