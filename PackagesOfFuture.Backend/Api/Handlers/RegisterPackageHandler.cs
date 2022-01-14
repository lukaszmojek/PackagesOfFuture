using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Dtos;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ResourceEnums;
using System.Data;

namespace Api.Handlers
{
    public class RegisterPackageHandler : IRequestHandler<RegisterPackageCommand, Response<RegisterPackageResponse>>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Sorting> _sortingRepository;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public RegisterPackageHandler(
            IRepository<Package> packageRepository,
            IRepository<Address> addressRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Service> serviceRepository,
            IRepository<Sorting> sortingRepository,
            IMapper mapper, DbContext dbContext)
        {
            _packageRepository = packageRepository;
            _addressRepository = addressRepository;
            _serviceRepository = serviceRepository;
            _paymentRepository = paymentRepository;
            _serviceRepository = serviceRepository;
            _sortingRepository = sortingRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Response<RegisterPackageResponse>> Handle(RegisterPackageCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _dbContext.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var addresses = await _addressRepository.GetAsync();
                    var sortings = await _sortingRepository.GetAsync();

                    var pickupAddress = addresses.FirstOrDefault(x => AddressesAreEqual(x, request.ReceiveAddress));
                    var destinationAddress = addresses.FirstOrDefault(x => AddressesAreEqual(x, request.DeliveryAddress));
                    var defaultSorting = sortings.FirstOrDefault();

                    var package = _mapper.Map<Package>(request.Package);

                    if (pickupAddress == null)
                    {
                        var pickupAddressEntity = _mapper.Map<Address>(request.ReceiveAddress);
                        await _addressRepository.AddAsync(pickupAddressEntity);
                        package.ReceiveAddress = pickupAddressEntity;
                    }
                    else
                    {
                        package.ReceiveAddressId = pickupAddress.Id;
                    }

                    if (destinationAddress == null)
                    {
                        var deliveryAddressEntity = _mapper.Map<Address>(request.DeliveryAddress);
                        await _addressRepository.AddAsync(deliveryAddressEntity);
                        package.DeliveryAddress = deliveryAddressEntity;
                    }
                    else
                    {
                        package.DeliveryAddressId = destinationAddress.Id;
                    }

                    var service = await _serviceRepository.GetByIdAsync(request.ServiceId);
                    package.Service = service;

                    if (service == null)
                    {
                        throw new ArgumentException(nameof(request.ServiceId));
                    }

                    var payment = _mapper.Map<Payment>(request.Payment);
                    payment.Status = PaymentStatus.InProgress;
                    await _paymentRepository.AddAsync(payment);
                    await _paymentRepository.SaveChangesAsync();

                    package.Id = 10;
                    package.Payment = payment;
                    package.DeliveryDate = DateTime.UtcNow.AddDays(4);

                    if (defaultSorting == null)
                    {
                        throw new ArgumentException(nameof(defaultSorting));
                    }

                    package.Sorting = defaultSorting;

                    await _packageRepository.AddAsync(package);
                    await _packageRepository.SaveChangesAsync();

                    transaction.Commit();

                    return ResponseFactory.CreateSuccessResponse<RegisterPackageResponse>();
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        private bool AddressesAreEqual(Address address, AddressDto requestDeliveryAddress)
        {
            return address.City == requestDeliveryAddress.City &&
                   address.Street == requestDeliveryAddress.Street &&
                   address.PostalCode == requestDeliveryAddress.PostalCode &&
                   address.HouseAndFlatNumber == requestDeliveryAddress.HouseAndFlatNumber;
        }
    }
}