using Api.Commands;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;

namespace Api.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>();

            CreateMap<ChangePaymentStatusDto, ChangePaymentStatusCommand>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<CreatePaymentDto, PaymentDto>();
        }
    }
}