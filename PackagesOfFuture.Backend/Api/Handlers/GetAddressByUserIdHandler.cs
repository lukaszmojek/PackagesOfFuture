using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dtos;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Controllers;

public class GetAddressByUserIdHandler : IRequestHandler<GetAddressByUserIdQuery, AddressDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetAddressByUserIdHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<AddressDto> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
    {
        var addressEntity = await _repository.GetAddressByUserId(request.UserId);

        var addressDto = _mapper.Map<AddressDto>(addressEntity);

        return addressDto;
    }
}