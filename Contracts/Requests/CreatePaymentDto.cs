using ResourceEnums;

namespace Contracts.Requests
{
    public class CreatePaymentDto
    {
        public PaymentType Type { get; set; }
        public double Amount { get; set; }
    }
}