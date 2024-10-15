using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteIngredient;

public class DeleteIngredientCommand : Command<DeleteIngredientCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteIngredientCommand(Guid id)
    {
        Id = id;
    }
}
