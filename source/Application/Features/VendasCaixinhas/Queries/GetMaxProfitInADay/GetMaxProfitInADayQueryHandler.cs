using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Services;

namespace Project.Application.Features.Queries.GetMaxProfitInADay
{
    public class GetMaxProfitInADayQueryHandler : IRequestHandler<GetMaxProfitInADayQuery, GetMaxProfitInADayQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasMetricsService _metricsService;

        public GetMaxProfitInADayQueryHandler(IMediator mediator, IVendasCaixinhasMetricsService metricsService)
        {
            _mediator = mediator;
            _metricsService = metricsService;
        }

        public async Task<GetMaxProfitInADayQueryResponse?> Handle(GetMaxProfitInADayQuery request, CancellationToken cancellationToken)
        {
            var maxProfit = await _metricsService.GetMaxProfitInADayAsync(request.Year, request.Month, cancellationToken);

            return new GetMaxProfitInADayQueryResponse
            {
                MaxProfit = maxProfit
            };
        }
    }
}
