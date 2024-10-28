using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteProduction;

public class DeleteProductionCommand : Command<DeleteProductionCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteProductionCommand(Guid id)
    {
        Id = id;
    }
}
