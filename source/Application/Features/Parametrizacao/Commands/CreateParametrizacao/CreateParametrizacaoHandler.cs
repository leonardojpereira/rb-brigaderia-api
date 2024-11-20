using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateParametrizacao;

public class CreateParametrizacaoCommandHandler : IRequestHandler<CreateParametrizacaoCommand, CreateParametrizacaoCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IParametrizacaoRepository _parametrizacaoRepository;
    private readonly IMediator _mediator;

    public CreateParametrizacaoCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IParametrizacaoRepository parametrizacaoRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _parametrizacaoRepository = parametrizacaoRepository;
    }

    public async Task<CreateParametrizacaoCommandResponse?> Handle(CreateParametrizacaoCommand request, CancellationToken cancellationToken)
    {
        var parametrizacao = new Parametrizacao
        {
            NomeVendedor = request.Request.NomeVendedor,
            PrecoCaixinha = request.Request.PrecoCaixinha,
            Custo = request.Request.Custo,
            Lucro = request.Request.Lucro,
            LocalVenda = request.Request.LocalVenda,
            HorarioInicio = request.Request.HorarioInicio,
            HorarioFim = request.Request.HorarioFim
        };

        _parametrizacaoRepository.Add(parametrizacao);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("CreateParametrizacao", "Parametrização criada com sucesso!"), cancellationToken);

        return new CreateParametrizacaoCommandResponse
        {
            Id = parametrizacao.Id,
            NomeVendedor = parametrizacao.NomeVendedor
        };
    }
}
