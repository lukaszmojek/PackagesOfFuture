using ResourceEnums;

namespace Contracts.Dtos
{
    public class ChangePaymentStatusDto
    {
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}