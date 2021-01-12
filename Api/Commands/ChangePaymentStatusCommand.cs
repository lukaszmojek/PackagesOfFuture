using Contracts.Reponses;
using Contracts.Responses;
using MediatR;
using Persistance;

namespace Api.Commands
{
    public class ChangePaymentStatusCommand : IRequest<Response<ChangePaymentStatusResponse>>
    {
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}