﻿using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAvgRentPriceForWeeklyQuery : IRequest<GetAvgRentPriceForWeeklyQueryResult>
    {
    }
}
