using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteRecipe;

public class DeleteRecipeCommand : Command<DeleteRecipeCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteRecipeCommand(Guid id)
    {
        Id = id;
    }
}
