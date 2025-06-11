﻿using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand : IRequest
    {
        public int CarId { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
