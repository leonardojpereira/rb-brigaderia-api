using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateParametrizacao;

public class UpdateParametrizacaoCommand : Command<UpdateParametrizacaoCommandResponse>
{
    public Guid Id { get; set; }
    public UpdateParametrizacaoCommandRequest Request { get; set; }

    public UpdateParametrizacaoCommand(UpdateParametrizacaoCommandRequest request, Guid id)
    {
        Request = request;
        Id = id;
    }
}
