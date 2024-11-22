using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateVendasCaixinhas;

public class CreateVendasCaixinhasCommandHandler : IRequestHandler<CreateVendasCaixinhasCommand, CreateVendasCaixinhasCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;
    private readonly IMediator _mediator;

    public CreateVendasCaixinhasCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IVendasCaixinhasRepository vendasCaixinhasRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _vendasCaixinhasRepository = vendasCaixinhasRepository;
    }

    public async Task<CreateVendasCaixinhasCommandResponse?> Handle(CreateVendasCaixinhasCommand request, CancellationToken cancellationToken)
    {
        var vendasCaixinhas = new VendasCaixinhas
        {
            DataVenda = request.Request.DataVenda,
            QuantidadeCaixinhas = request.Request.QuantidadeCaixinhas,
            PrecoTotalVenda = request.Request.PrecoTotalVenda,
            Salario = request.Request.Salario,
            CustoTotal = request.Request.CustoTotal,
            Lucro = request.Request.Lucro,
            LocalVenda = request.Request.LocalVenda,
            HorarioInicio = request.Request.HorarioInicio,
            HorarioFim = request.Request.HorarioFim,
            NomeVendedor = request.Request.NomeVendedor
        };

        _vendasCaixinhasRepository.Add(vendasCaixinhas);
         _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("CreateVendasCaixinhas", "Venda registrada com sucesso!"), cancellationToken);

        return new CreateVendasCaixinhasCommandResponse
        {
            Id = vendasCaixinhas.Id,
            DataVenda = vendasCaixinhas.DataVenda
        };
    }
}
