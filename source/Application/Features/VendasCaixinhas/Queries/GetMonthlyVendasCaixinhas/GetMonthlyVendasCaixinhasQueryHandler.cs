using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Application.Features.Queries.GetMonthlyVendasCaixinhas;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetMonthlySalesSummary
{
    public class GetMonthlyVendasCaixinhasQueryHandler : IRequestHandler<GetMonthlyVendasCaixinhasQuery, GetMonthlyVendasCaixinhasQueryResponse>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

        public GetMonthlyVendasCaixinhasQueryHandler(IMediator mediator, IVendasCaixinhasRepository vendasCaixinhasRepository)
        {
            _mediator = mediator;
            _vendasCaixinhasRepository = vendasCaixinhasRepository;
        }

        public async Task<GetMonthlyVendasCaixinhasQueryResponse> Handle(GetMonthlyVendasCaixinhasQuery request, CancellationToken cancellationToken)
        {
            var (totalCusto, totalLucro, quantidadeVendas) = await _vendasCaixinhasRepository
                .GetMonthlySalesSummaryAsync(request.Year, request.Month, cancellationToken);

            await _mediator.Publish(new DomainSuccessNotification("GetMonthlySalesSummary", "Monthly sales summary retrieved successfully"), cancellationToken);

            return new GetMonthlyVendasCaixinhasQueryResponse
            {
                TotalCusto = totalCusto,
                TotalLucro = totalLucro,
                QuantidadeVendas = quantidadeVendas
            };
        }
    }
}
