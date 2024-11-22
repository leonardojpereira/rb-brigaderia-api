using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllParametrizacao;

public class GetAllParametrizacaoQueryHandler : IRequestHandler<GetAllParametrizacaoQuery, GetAllParametrizacaoQueryResponse?>
{
    private readonly IMediator _mediator;
    private readonly IParametrizacaoRepository _parametrizacaoRepository;

    public GetAllParametrizacaoQueryHandler(IMediator mediator, IParametrizacaoRepository parametrizacaoRepository)
    {
        _mediator = mediator;
        _parametrizacaoRepository = parametrizacaoRepository;
    }

    public async Task<GetAllParametrizacaoQueryResponse?> Handle(GetAllParametrizacaoQuery request, CancellationToken cancellationToken)
    {
        var allParametrizacoes = await _parametrizacaoRepository.GetAllAsync(cancellationToken);

        if (!string.IsNullOrEmpty(request.NomeVendedor))
        {
            allParametrizacoes = allParametrizacoes
                .Where(p => p.NomeVendedor.Contains(request.NomeVendedor, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var orderedParametrizacoes = allParametrizacoes.OrderBy(p => p.NomeVendedor).ToList();

        var totalItems = orderedParametrizacoes.Count();

        var paginatedParametrizacoes = orderedParametrizacoes
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var parametrizacaoDTOs = paginatedParametrizacoes
            .Select(p => new GetAllParametrizacaoDTO
            {
                Id = p.Id,
                NomeVendedor = p.NomeVendedor,
                PrecoCaixinha = p.PrecoCaixinha,
                Custo = p.Custo,
                Lucro = p.Lucro,
                LocalVenda = p.LocalVenda,
                HorarioInicio = p.HorarioInicio,
                HorarioFim = p.HorarioFim,
                PrecisaPassagem = p.PrecisaPassagem,
                PrecoPassagem = p.PrecoPassagem
            })
            .ToList();

        await _mediator.Publish(new DomainSuccessNotification("GetAllParametrizacao", "Parametrizações retrieved successfully"), cancellationToken);

        return new GetAllParametrizacaoQueryResponse
        {
            Parametrizacoes = parametrizacaoDTOs,
            TotalItems = totalItems,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
