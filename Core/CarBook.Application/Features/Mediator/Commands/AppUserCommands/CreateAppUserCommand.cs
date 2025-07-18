﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.RegisterCommands
{
    public class CreateAppUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

    }
}
