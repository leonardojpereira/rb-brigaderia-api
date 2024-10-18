using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateRecipe;

public class UpdateRecipeCommand : Command<UpdateRecipeCommandResponse>
{
    public Guid Id { get; set; }
    public UpdateRecipeCommandRequest Request { get; set; }
    public UpdateRecipeCommand(UpdateRecipeCommandRequest request, Guid id)
    {
        Request = request;
        Id = id;
    }
}
