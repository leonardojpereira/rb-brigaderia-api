using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateVendasCaixinhas
{
    public class UpdateVendasCaixinhasCommandHandler : IRequestHandler<UpdateVendasCaixinhasCommand, UpdateVendasCaixinhasCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

        public UpdateVendasCaixinhasCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IVendasCaixinhasRepository vendasCaixinhasRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _vendasCaixinhasRepository = vendasCaixinhasRepository;
        }

        public async Task<UpdateVendasCaixinhasCommandResponse?> Handle(UpdateVendasCaixinhasCommand request, CancellationToken cancellationToken)
        {
            var vendaCaixinhas = await _vendasCaixinhasRepository.GetByIdAsync(request.Id, cancellationToken);

            if (vendaCaixinhas is null)
            {
                await _mediator.Publish(new DomainNotification("UpdateVendasCaixinhas", "Venda de caixinhas não encontrada"), cancellationToken);
                return default;
            }

            vendaCaixinhas.DataVenda = request.Request.DataVenda ?? vendaCaixinhas.DataVenda;
            vendaCaixinhas.QuantidadeCaixinhas = request.Request.QuantidadeCaixinhas ?? vendaCaixinhas.QuantidadeCaixinhas;
            vendaCaixinhas.PrecoTotalVenda = request.Request.PrecoTotalVenda ?? vendaCaixinhas.PrecoTotalVenda;
            vendaCaixinhas.Salario = request.Request.Salario ?? vendaCaixinhas.Salario;
            vendaCaixinhas.CustoTotal = request.Request.CustoTotal ?? vendaCaixinhas.CustoTotal;
            vendaCaixinhas.Lucro = request.Request.Lucro ?? vendaCaixinhas.Lucro;
            vendaCaixinhas.LocalVenda = request.Request.LocalVenda ?? vendaCaixinhas.LocalVenda;
            vendaCaixinhas.HorarioInicio = request.Request.HorarioInicio ?? vendaCaixinhas.HorarioInicio;
            vendaCaixinhas.HorarioFim = request.Request.HorarioFim ?? vendaCaixinhas.HorarioFim;

            var updateResult = _vendasCaixinhasRepository.Update(vendaCaixinhas);
            _unitOfWork.Commit();

            await _mediator.Publish(new DomainSuccessNotification("UpdateVendasCaixinhas", "Venda de caixinhas atualizada com sucesso"), cancellationToken);

            return new UpdateVendasCaixinhasCommandResponse
            {
                Id = updateResult.Id,
                DataVenda = updateResult.DataVenda,
                QuantidadeCaixinhas = updateResult.QuantidadeCaixinhas,
                PrecoTotalVenda = updateResult.PrecoTotalVenda,
                Salario = updateResult.Salario,
                CustoTotal = updateResult.CustoTotal,
                Lucro = updateResult.Lucro,
                LocalVenda = updateResult.LocalVenda,
                HorarioInicio = updateResult.HorarioInicio,
                HorarioFim = updateResult.HorarioFim
            };
        }
    }
}
