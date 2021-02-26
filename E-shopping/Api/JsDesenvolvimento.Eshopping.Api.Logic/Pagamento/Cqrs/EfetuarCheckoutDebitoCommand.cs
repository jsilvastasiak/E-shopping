using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Logic.Pagamento.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pagamento.Cqrs
{
    public class EfetuarCheckoutDebitoCommand: IRequest<EfetuarCheckoutCommandResponse>
    {
        public EfetuarCheckoutDebitoCommand(EfetuarCheckoutCommandRequest request, IUserRef userRef)
        {
            Request = request;
            UserRef = userRef;
        }

        public EfetuarCheckoutCommandRequest Request { get; }
        public IUserRef UserRef { get; }
    }
}
