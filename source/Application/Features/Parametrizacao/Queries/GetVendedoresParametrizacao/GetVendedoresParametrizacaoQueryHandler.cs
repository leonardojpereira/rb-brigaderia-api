using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetVendedoresParametrizacao;

public class GetVendedoresParametrizacaoQueryHandler : IRequestHandler<GetVendedoresParametrizacaoQuery, GetVendedoresParametrizacaoQueryResponse?>
{
    private readonly IMediator _mediator;
    private readonly IParametrizacaoRepository _parametrizacaoRepository;

    public GetVendedoresParametrizacaoQueryHandler(IMediator mediator, IParametrizacaoRepository parametrizacaoRepository)
    {
        _mediator = mediator;
        _parametrizacaoRepository = parametrizacaoRepository;
    }

    public async Task<GetVendedoresParametrizacaoQueryResponse?> Handle(GetVendedoresParametrizacaoQuery request, CancellationToken cancellationToken)
    {
        var allParametrizacoes = await _parametrizacaoRepository.GetAllAsync(cancellationToken);

        // Seleciona apenas os IDs e Nomes dos Vendedores
        var vendedoresDTO = allParametrizacoes
            .Select(p => new GetVendedoresParametrizacaoDTO
            {
                Id = p.Id,
                NomeVendedor = p.NomeVendedor
            })
            .OrderBy(v => v.NomeVendedor) // Ordena por Nome
            .ToList();

        await _mediator.Publish(new DomainSuccessNotification("GetVendedoresParametrizacao", "Lista de vendedores retrieved successfully"), cancellationToken);

        return new GetVendedoresParametrizacaoQueryResponse
        {
            Vendedores = vendedoresDTO
        };
    }
}
