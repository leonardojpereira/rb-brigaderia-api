using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllVendasCaixinhas
{
    public class GetAllVendasCaixinhasQueryHandler : IRequestHandler<GetAllVendasCaixinhasQuery, GetAllVendasCaixinhasQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

        public GetAllVendasCaixinhasQueryHandler(IMediator mediator, IVendasCaixinhasRepository vendasCaixinhasRepository)
        {
            _mediator = mediator;
            _vendasCaixinhasRepository = vendasCaixinhasRepository;
        }

        public async Task<GetAllVendasCaixinhasQueryResponse?> Handle(GetAllVendasCaixinhasQuery request, CancellationToken cancellationToken)
        {
            var allVendas = await _vendasCaixinhasRepository.GetAllAsync(cancellationToken);

            if (request.Date.HasValue)
            {
                allVendas = allVendas.Where(v => v.DataVenda.Date == request.Date.Value.Date).ToList();
            }

            var totalVendas = allVendas.Count();

            var paginatedVendas = allVendas
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var vendasCaixinhasDTOs = paginatedVendas
                .Select(venda => new GetAllVendasCaixinhasDTO
                {
                    Id = venda.Id,
                    DataVenda = venda.DataVenda,
                    QuantidadeCaixinhas = venda.QuantidadeCaixinhas,
                    PrecoTotalVenda = venda.PrecoTotalVenda,
                    Salario = venda.Salario,
                    CustoTotal = venda.CustoTotal,
                    Lucro = venda.Lucro,
                    LocalVenda = venda.LocalVenda,
                    HorarioInicio = venda.HorarioInicio,
                    HorarioFim = venda.HorarioFim
                })
                .ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllVendasCaixinhas", "Vendas caixinhas retrieved successfully"), cancellationToken);

            return new GetAllVendasCaixinhasQueryResponse
            {
                VendasCaixinhas = vendasCaixinhasDTOs,
                TotalItems = totalVendas,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
