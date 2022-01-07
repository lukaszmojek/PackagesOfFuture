﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing on drones
    /// </summary>
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public DronesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Gets all drones
        /// </summary>
        /// <returns>All drones from database</returns>
        /// <response code="200">When there are drones</response>
        /// <response code="404">If there are no drones</response>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<DroneDto>>> GetDrones()
        {
            var result = await _mediator.Send(new GetDronesQuery());
            return result.Any() ? (ActionResult<ICollection<DroneDto>>) Ok(result) : NotFound();
        }
        
        /// <summary>
        /// Registers a new drone
        /// </summary>
        /// <param name="registerDroneDto">Representation of drone to register</param>
        /// <returns>Nothing. Query GetPackages for current database status</returns>
        /// <response code="204">When drone was registered</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("")]
        public async Task<IActionResult> RegisterDrone([FromBody] RegisterDroneDto registerDroneDto)
        {
            var command = _mapper.Map<RegisterDroneCommand>(registerDroneDto);
            var result = await _mediator.Send(command);
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
        }

        /// <summary>
        /// Moves drone to different sorting
        /// </summary>
        /// <param name="droneId">Id of drone</param>
        /// <param name="moveDroneDroneToSortingDto">Details of moving drone</param>
        /// <returns>Nothing. Query GetDrones for current database status</returns>
        /// <response code="204">When drone was moved</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("{droneId}/move-to-sorting")]
        public async Task<IActionResult> MoveDroneToSorting(
            [FromRoute] int droneId,
            [FromBody] MoveDroneToSortingDto moveDroneDroneToSortingDto)
        {
            var command = _mapper.Map<MoveDroneToSortingCommand>(moveDroneDroneToSortingDto);
            var result = await _mediator.Send(command);
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
        }

        /// <summary>
        /// Unregisters drone
        /// </summary>
        /// <param name="droneId">Id of drone</param>
        /// <returns>Nothing. Query GetDrones for current database status</returns>
        /// <response code="204">When drone was moved</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpDelete("{droneId}/unregister")]
        public async Task<IActionResult> UnregisterDrone(
            [FromRoute] int droneId
            )
        {
            var result = await _mediator.Send(new UnregisterDroneCommand() { Id = droneId });
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
        }
    }

    public class UnregisterDroneCommand : IRequest<Response<UnregisterDroneResponse>>
    {
        public int Id { get; set; }
    }

    public class UnregisterDroneResponse : IResponse
    {
    }
    
    public class UnregisterDroneHandler : IRequestHandler<UnregisterDroneCommand, Response<UnregisterDroneResponse>>
    {
        private IRepository<Drone> _repository;

        public UnregisterDroneHandler(IRepository<Drone> repository)
        {
            _repository = repository;
        }

        public async Task<Response<UnregisterDroneResponse>> Handle(UnregisterDroneCommand request, CancellationToken cancellationToken)
        {
            var drone = await _repository.GetByIdAsync(request.Id);
            _repository.Delete(drone);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<UnregisterDroneResponse>();
        }
    }
}