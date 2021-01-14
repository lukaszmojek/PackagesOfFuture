using Contracts.Responses;
using MediatR;
using ResourceEnums;

namespace Api.Commands
{
    public class ChangePaymentStatusCommand : IRequest<Response<ChangePaymentStatusResponse>>
    {
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}