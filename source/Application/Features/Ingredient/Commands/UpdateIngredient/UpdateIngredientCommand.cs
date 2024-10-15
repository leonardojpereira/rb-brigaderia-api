using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateIngredient;

public class UpdateIngredientCommand : Command<UpdateIngredientCommandResponse>
{
    public Guid Id { get; set; }
    public UpdateIngredientCommandRequest Request { get; set; }
    public UpdateIngredientCommand(UpdateIngredientCommandRequest request, Guid id)
    {
        Request = request;
        Id = id;
    }
}
