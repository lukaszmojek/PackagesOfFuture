using ResourceEnums;

namespace Contracts.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public PaymentType Type { get; set; }
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }
    }
}