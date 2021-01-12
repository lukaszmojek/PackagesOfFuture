using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetPaymentsQuery : IRequest<ICollection<PaymentDto>>
    {
      
    }
}
