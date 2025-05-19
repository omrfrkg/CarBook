using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var result = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var result = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new DeleteFooterAddressCommand(id));
            return Ok("Alt Adres Bilgisi Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Güncellendi.");
        }

    }
}
