using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateStockMovement;

public class UpdateStockMovementCommand : Command<UpdateStockMovementCommandResponse>
{
    public UpdateStockMovementCommandRequest Request { get; set; }

    public UpdateStockMovementCommand(UpdateStockMovementCommandRequest request)
    {
        Request = request;
    }
}
