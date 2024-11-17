using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Services;

namespace Project.Application.Features.Queries.GetMonthWithMostSales
{
    public class GetMonthWithMostSalesQueryHandler : IRequestHandler<GetMonthWithMostSalesQuery, GetMonthWithMostSalesQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasMetricsService _metricsService;

        public GetMonthWithMostSalesQueryHandler(IMediator mediator, IVendasCaixinhasMetricsService metricsService)
        {
            _mediator = mediator;
            _metricsService = metricsService;
        }

       public async Task<GetMonthWithMostSalesQueryResponse?> Handle(GetMonthWithMostSalesQuery request, CancellationToken cancellationToken)
    {
        var monthlySales = await _metricsService.GetMonthlySalesAsync(request.Year, cancellationToken);

        var response = new GetMonthWithMostSalesQueryResponse
        {
            MonthlySales = monthlySales.Select(ms => new MonthSalesDTO
            {
                Month = ms.Month,
                TotalSales = ms.TotalSales
            }).ToList()
        };

        return response;
    }
    }
}
