using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateParametrizacao;

public class UpdateParametrizacaoCommandHandler : IRequestHandler<UpdateParametrizacaoCommand, UpdateParametrizacaoCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IParametrizacaoRepository _parametrizacaoRepository;

    public UpdateParametrizacaoCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IParametrizacaoRepository parametrizacaoRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _parametrizacaoRepository = parametrizacaoRepository;
    }

   public async Task<UpdateParametrizacaoCommandResponse?> Handle(UpdateParametrizacaoCommand request, CancellationToken cancellationToken)
{
    var parametrizacao = await _parametrizacaoRepository.GetByIdAsync(request.Id, cancellationToken);

    if (parametrizacao is null)
    {
        await _mediator.Publish(new DomainNotification("UpdateParametrizacao", "Parametrização não encontrada"), cancellationToken);
        return default;
    }

    parametrizacao.NomeVendedor = request.Request.NomeVendedor ?? parametrizacao.NomeVendedor;
    parametrizacao.PrecoCaixinha = request.Request.PrecoCaixinha ?? parametrizacao.PrecoCaixinha;
    parametrizacao.Custo = request.Request.Custo ?? parametrizacao.Custo;
    parametrizacao.Lucro = request.Request.Lucro ?? parametrizacao.Lucro;
    parametrizacao.LocalVenda = request.Request.LocalVenda ?? parametrizacao.LocalVenda;
    parametrizacao.HorarioInicio = request.Request.HorarioInicio ?? parametrizacao.HorarioInicio;
    parametrizacao.HorarioFim = request.Request.HorarioFim ?? parametrizacao.HorarioFim;

    // Atualizar PrecisaPassagem
    parametrizacao.PrecisaPassagem = request.Request.PrecisaPassagem;

    // Limpar PrecoPassagem se PrecisaPassagem for false
    parametrizacao.PrecoPassagem = request.Request.PrecisaPassagem ? request.Request.PrecoPassagem : null;

    var updatedParametrizacao = _parametrizacaoRepository.Update(parametrizacao);
    _unitOfWork.Commit();

    await _mediator.Publish(new DomainSuccessNotification("UpdateParametrizacao", "Parametrização atualizada com sucesso"), cancellationToken);

    return new UpdateParametrizacaoCommandResponse
    {
        Id = updatedParametrizacao.Id,
        NomeVendedor = updatedParametrizacao.NomeVendedor,
        PrecoCaixinha = updatedParametrizacao.PrecoCaixinha,
        Custo = updatedParametrizacao.Custo,
        Lucro = updatedParametrizacao.Lucro,
        LocalVenda = updatedParametrizacao.LocalVenda,
        HorarioInicio = updatedParametrizacao.HorarioInicio,
        HorarioFim = updatedParametrizacao.HorarioFim,
        PrecisaPassagem = updatedParametrizacao.PrecisaPassagem,
        PrecoPassagem = updatedParametrizacao.PrecoPassagem
    };
}

}
