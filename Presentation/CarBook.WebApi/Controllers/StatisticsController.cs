using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var result = await _mediator.Send(new GetCarCountQuery());
            return Ok(result);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var result = await _mediator.Send(new GetLocationCountQuery());
            return Ok(result);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var result = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(result);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var result = await _mediator.Send(new GetBlogCountQuery());
            return Ok(result);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var result = await _mediator.Send(new GetBrandCountQuery());
            return Ok(result);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(result);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(result);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(result);
        }

        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var result = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(result);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var result = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(result);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var result = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(result);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var result = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(result);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var result = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(result);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var result = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(result);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var result = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(result);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var result = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(result);
        }
    }
}
