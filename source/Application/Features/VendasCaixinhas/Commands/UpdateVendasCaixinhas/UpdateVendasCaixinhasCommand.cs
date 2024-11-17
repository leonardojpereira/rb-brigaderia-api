using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateVendasCaixinhas
{
    public class UpdateVendasCaixinhasCommand : Command<UpdateVendasCaixinhasCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateVendasCaixinhasCommandRequest Request { get; set; }

        public UpdateVendasCaixinhasCommand(UpdateVendasCaixinhasCommandRequest request, Guid id)
        {
            Request = request;
            Id = id;
        }
    }
}
