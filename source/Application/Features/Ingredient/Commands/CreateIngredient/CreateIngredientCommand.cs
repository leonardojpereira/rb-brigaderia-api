using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateIngredient;

public class CreateIngredientCommand : Command<CreateIngredientCommandResponse>
{
    public CreateIngredientCommandRequest Request { get; set; }
    public CreateIngredientCommand(CreateIngredientCommandRequest request)
    {
        Request = request;
    }
}
