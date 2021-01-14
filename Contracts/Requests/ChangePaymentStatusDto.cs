using ResourceEnums;

namespace Contracts.Requests
{
    public class ChangePaymentStatusDto
    {
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}