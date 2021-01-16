using ResourceEnums;

namespace Contracts.Dtos
{
    public class CreatePaymentDto
    {
        public PaymentType Type { get; set; }
        public double Amount { get; set; }
    }
}