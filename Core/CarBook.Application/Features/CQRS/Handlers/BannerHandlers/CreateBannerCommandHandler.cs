﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.AddAsync(new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
