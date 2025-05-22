﻿using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public DeleteAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
