using MediatR;

namespace Project.Application.Features.Commands.CreateParametrizacao;

public class CreateParametrizacaoCommand : IRequest<CreateParametrizacaoCommandResponse?>
{
    public CreateParametrizacaoCommandRequest Request { get; set; }

    public CreateParametrizacaoCommand(CreateParametrizacaoCommandRequest request)
    {
        Request = request;
    }
}
