using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateProduction;

public class UpdateProductionCommand : Command<UpdateProductionCommandResponse>
{
    public Guid Id { get; set; }
    public UpdateProductionCommandRequest Request { get; set; }
    public UpdateProductionCommand(UpdateProductionCommandRequest request, Guid id)
    {
        Request = request;
        Id = id;
    }
}
