using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Queries.GetBestSellingDay;
using Project.Application.Features.Queries.GetMonthWithMostSales;
using Project.Application.Features.Queries.GetMaxProfitInADay;
using Project.Application.Features.Queries.GetMonthlyVendasCaixinhas;

namespace Project.WebApi.Controllers
{
    public class VendasCaixinhasMetricsController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin, User")]
        [HttpGet("best-selling-day")]
        [ProducesResponseType(typeof(GetBestSellingDayQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBestSellingDay(
            [FromQuery] int year, 
            [FromQuery] int month, 
            CancellationToken cancellationToken)
        {
            var query = new GetBestSellingDayQuery(year, month);
            return Response(await _mediatorHandler.Send(query, cancellationToken));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("month-with-most-sales")]
        [ProducesResponseType(typeof(GetMonthWithMostSalesQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMonthWithMostSales(
            [FromQuery] int year, 
            CancellationToken cancellationToken)
        {
            var query = new GetMonthWithMostSalesQuery(year);
            return Response(await _mediatorHandler.Send(query, cancellationToken));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("max-profit-day")]
        [ProducesResponseType(typeof(GetMaxProfitInADayQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMaxProfitInADay(
            [FromQuery] int year, 
            [FromQuery] int month, 
            CancellationToken cancellationToken)
        {
            var query = new GetMaxProfitInADayQuery(year, month);
            return Response(await _mediatorHandler.Send(query, cancellationToken));
        }

        [HttpGet("monthly-sales")]
        [ProducesResponseType(typeof(GetMonthlyVendasCaixinhasQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMonthlySales([FromQuery] int year, [FromQuery] int month, CancellationToken cancellationToken)
        {
            var query = new GetMonthlyVendasCaixinhasQuery(year, month);
            return Response(await _mediatorHandler.Send(query, cancellationToken));
        }
    }
}
