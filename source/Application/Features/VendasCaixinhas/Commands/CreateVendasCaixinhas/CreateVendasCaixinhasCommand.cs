using MediatR;

namespace Project.Application.Features.Commands.CreateVendasCaixinhas;

public class CreateVendasCaixinhasCommand : IRequest<CreateVendasCaixinhasCommandResponse?>
{
    public CreateVendasCaixinhasCommandRequest Request { get; set; }
    public CreateVendasCaixinhasCommand(CreateVendasCaixinhasCommandRequest request)
    {
        Request = request;
    }
}
