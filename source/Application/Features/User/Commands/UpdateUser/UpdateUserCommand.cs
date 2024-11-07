using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommand : Command<UpdateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateUserCommandRequest Request { get; set; }
        public UpdateUserCommand(UpdateUserCommandRequest request, Guid id)
        {
            Request = request;
            Id = id;
        }
    }
}
