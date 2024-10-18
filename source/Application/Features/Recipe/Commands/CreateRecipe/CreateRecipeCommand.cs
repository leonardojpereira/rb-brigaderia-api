using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateRecipe;

public class CreateRecipeCommand : Command<CreateRecipeCommandResponse>
{
    public CreateRecipeCommandRequest Request { get; set; }
    public CreateRecipeCommand(CreateRecipeCommandRequest request)
    {
        Request = request;
    }
}
