using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model
{
    public class CompraPessoa
    {
        public int idpessoa { get; set; }
        public long idcompra { get; set; }
        public long idproduto { get; set; }
        public int quantidade { get; set; }
        public decimal valorunitario { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string sitcompra { get; set; }
        public DateTimeOffset datacompra { get; set; }
    }
}
