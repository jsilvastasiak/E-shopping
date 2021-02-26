using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Logic.Pagamento.Model;
using JsDesenvolvimento.Pagamento;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pagamento.Cqrs
{
    public class EfetuarCheckoutCommandHandler : IRequestHandler<EfetuarCheckoutDebitoCommand, EfetuarCheckoutCommandResponse>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }
        public IPagamentoClient Client { get; }

        public EfetuarCheckoutCommandHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory, IPagamentoClient client)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
            Client = client;
        }

        public Task<EfetuarCheckoutCommandResponse> Handle(EfetuarCheckoutDebitoCommand request, CancellationToken cancellationToken)
        {
            var response = Client.PostDebito(new JsDesenvolvimento.Pagamento.Modelo.ReqCheckoutDebito()
            {
                
            }, cancellationToken).Result;

            return Task.FromResult(new EfetuarCheckoutCommandResponse()
            {
                
            });
        }
    }
}
