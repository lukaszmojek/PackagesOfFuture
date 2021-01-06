using AutoMapper;
using Contracts.Requests;
using Persistance.Entities;

namespace Api.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>();
        }
    }
}