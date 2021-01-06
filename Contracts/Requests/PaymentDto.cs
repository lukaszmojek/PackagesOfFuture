using Persistance;

namespace Contracts.Requests
{
    public class PaymentDto
    {
        public PaymentType Type { get; set; }
        public double Amount { get; set; }
    }
}