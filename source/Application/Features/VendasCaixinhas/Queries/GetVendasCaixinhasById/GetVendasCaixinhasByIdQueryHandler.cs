using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetVendasCaixinhasById
{
    public class GetVendasCaixinhasByIdQueryHandler : IRequestHandler<GetVendasCaixinhasByIdQuery, GetVendasCaixinhasByIdQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

        public GetVendasCaixinhasByIdQueryHandler(IMediator mediator, IVendasCaixinhasRepository vendasCaixinhasRepository)
        {
            _mediator = mediator;
            _vendasCaixinhasRepository = vendasCaixinhasRepository;
        }

        public async Task<GetVendasCaixinhasByIdQueryResponse?> Handle(GetVendasCaixinhasByIdQuery request, CancellationToken cancellationToken)
        {
            var vendaCaixinhas = await _vendasCaixinhasRepository.GetByIdAsync(request.Id, cancellationToken);

            if (vendaCaixinhas is null)
            {
                await _mediator.Publish(new DomainNotification("GetVendasCaixinhasById", "Venda de caixinhas não encontrada"), cancellationToken);
                return default;
            }

            await _mediator.Publish(new DomainSuccessNotification("GetVendasCaixinhasById", "Venda de caixinhas encontrada com sucesso"), cancellationToken);

            var vendaCaixinhasDTO = new GetVendasCaixinhasByIdDTO
            {
                Id = vendaCaixinhas.Id,
                DataVenda = vendaCaixinhas.DataVenda,
                QuantidadeCaixinhas = vendaCaixinhas.QuantidadeCaixinhas,
                PrecoTotalVenda = vendaCaixinhas.PrecoTotalVenda,
                Salario = vendaCaixinhas.Salario,
                CustoTotal = vendaCaixinhas.CustoTotal,
                Lucro = vendaCaixinhas.Lucro,
                LocalVenda = vendaCaixinhas.LocalVenda,
                HorarioInicio = vendaCaixinhas.HorarioInicio,
                HorarioFim = vendaCaixinhas.HorarioFim,
                NomeVendedor = vendaCaixinhas.NomeVendedor
            };

            return new GetVendasCaixinhasByIdQueryResponse { VendaCaixinhas = vendaCaixinhasDTO };
        }
    }
}
