using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteUser;

public class DeleteUserCommand : Command<DeleteUserCommandResponse>
{
    public Guid Id { get; set; }
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}
