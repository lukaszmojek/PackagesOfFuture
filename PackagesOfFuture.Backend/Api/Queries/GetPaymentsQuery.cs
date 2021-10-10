using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetPaymentsQuery : IRequest<ICollection<PaymentDto>>
    {
      
    }
}
