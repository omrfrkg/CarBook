﻿using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _mediator.Send(new DeleteTagCloudCommand(id));
            return Ok("Tag Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag Başarıyla Güncellendi.");
        }

        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }


    }
}
