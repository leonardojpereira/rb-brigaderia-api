using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetParametrizacaoById;

public class GetParametrizacaoByIdQueryHandler : IRequestHandler<GetParametrizacaoByIdQuery, GetParametrizacaoByIdQueryResponse?>
{
    private readonly IMediator _mediator;
    private readonly IParametrizacaoRepository _parametrizacaoRepository;

    public GetParametrizacaoByIdQueryHandler(IMediator mediator, IParametrizacaoRepository parametrizacaoRepository)
    {
        _mediator = mediator;
        _parametrizacaoRepository = parametrizacaoRepository;
    }

    public async Task<GetParametrizacaoByIdQueryResponse?> Handle(GetParametrizacaoByIdQuery request, CancellationToken cancellationToken)
    {
        var parametrizacao = await _parametrizacaoRepository.GetByIdAsync(request.Id, cancellationToken);

        if (parametrizacao is null)
        {
            await _mediator.Publish(new DomainNotification("GetParametrizacaoById", "Parametrização não encontrada"), cancellationToken);
            return default;
        }

        await _mediator.Publish(new DomainSuccessNotification("GetParametrizacaoById", "Parametrização encontrada com sucesso"), cancellationToken);

        var parametrizacaoDTO = new GetParametrizacaoByIdDTO
        {
            Id = parametrizacao.Id,
            NomeVendedor = parametrizacao.NomeVendedor,
            PrecoCaixinha = parametrizacao.PrecoCaixinha,
            Custo = parametrizacao.Custo,
            Lucro = parametrizacao.Lucro,
            LocalVenda = parametrizacao.LocalVenda,
            HorarioInicio = parametrizacao.HorarioInicio,
            HorarioFim = parametrizacao.HorarioFim,
            PrecisaPassagem = parametrizacao.PrecisaPassagem,
            PrecoPassagem = parametrizacao.PrecoPassagem
        };

        return new GetParametrizacaoByIdQueryResponse { Parametrizacao = parametrizacaoDTO };
    }
}
