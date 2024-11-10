using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Services;

namespace Project.Application.Features.Queries.GetBestSellingDay
{
    public class GetBestSellingDayQueryHandler : IRequestHandler<GetBestSellingDayQuery, GetBestSellingDayQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasMetricsService _metricsService;

        public GetBestSellingDayQueryHandler(IMediator mediator, IVendasCaixinhasMetricsService metricsService)
        {
            _mediator = mediator;
            _metricsService = metricsService;
        }

        public async Task<GetBestSellingDayQueryResponse?> Handle(GetBestSellingDayQuery request, CancellationToken cancellationToken)
        {
            var (day, totalSales) = await _metricsService.GetBestSellingDayAsync(request.Year, request.Month, cancellationToken);

            return new GetBestSellingDayQueryResponse
            {
                Day = day,
                TotalSales = totalSales
            };
        }
    }
}
