using JsDesenvolvimento.Pagamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Infraestrutura
{
    public class UriMapperPagseguro : IPagamentoUriMapper
    {
        public Uri GetUrlBase()
        {
            return new Uri("https://sandbox.api.pagseguro.com/digital-payments/v1/transactions/");
        }
    }
}
