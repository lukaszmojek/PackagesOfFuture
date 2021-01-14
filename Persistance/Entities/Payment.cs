using ResourceEnums;

namespace Data.Entities
{
    public class Payment : Entity
    {
        public PaymentType Type { get; set; }
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }
        
        public virtual Package Package { get; set; }
    }
}