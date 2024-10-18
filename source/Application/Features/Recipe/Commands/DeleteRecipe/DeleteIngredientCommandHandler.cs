using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteRecipe;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, DeleteRecipeCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IRecipeRepository _RecipeRepository;

    public DeleteRecipeCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IRecipeRepository RecipeRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _RecipeRepository = RecipeRepository;
    }

    public async Task<DeleteRecipeCommandResponse?> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var Recipe = _RecipeRepository.Get(Recipe => Recipe.Id == request.Id);

        if (Recipe is null)
        {
            await _mediator.Publish(new DomainNotification("DeleteRecipe", "Recipe not found"), cancellationToken);
            return default;
        }

        _RecipeRepository.Delete(Recipe);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("DeleteRecipe", "Recipe deleted successfully"), cancellationToken);
        var response = new DeleteRecipeCommandResponse { };
        return response;
    }
}