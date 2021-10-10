using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class ChangePaymentStatusHandler : IRequestHandler<ChangePaymentStatusCommand, Response<ChangePaymentStatusResponse>>
    {
        private IRepository<Payment> _repository;

        public ChangePaymentStatusHandler(IRepository<Payment> repository)
        {
            _repository = repository;
        }

        public async Task<Response<ChangePaymentStatusResponse>> Handle(ChangePaymentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _repository.GetByIdAsync(request.PaymentId);

                if (payment == null)
                {
                    throw new ArgumentException(nameof(request.PaymentId));
                }

                payment.Status = request.PaymentStatus;
                await _repository.SaveChangesAsync();

                return ResponseFactory.CreateSuccessResponse<ChangePaymentStatusResponse>();
            }
            catch (Exception e)
            {
                return ResponseFactory.CreateFailureResponse<ChangePaymentStatusResponse>();
            }
        }
    }
}
