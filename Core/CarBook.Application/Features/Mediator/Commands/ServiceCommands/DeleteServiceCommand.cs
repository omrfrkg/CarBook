﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteServiceCommand(int id)
        {
            Id = id;
        }
    }
}
