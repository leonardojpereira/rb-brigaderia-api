using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteParametrizacao;

public class DeleteParametrizacaoCommand : Command<DeleteParametrizacaoCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteParametrizacaoCommand(Guid id)
    {
        Id = id;
    }
}
