﻿using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeaturesByCarId(int id)
        {
            var result = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(result);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }


        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme Yapıldı");
        }
    }
}
