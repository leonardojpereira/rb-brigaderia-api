using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteVendasCaixinhas;

public class DeleteVendasCaixinhasCommand : Command<DeleteVendasCaixinhasCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteVendasCaixinhasCommand(Guid id)
    {
        Id = id;
    }
}
