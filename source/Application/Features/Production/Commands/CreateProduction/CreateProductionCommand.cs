using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateProduction
{
    public class CreateProductionCommand : Command<CreateProductionCommandResponse>
    {
        public CreateProductionCommandRequest Request { get; set; }
        public CreateProductionCommand(CreateProductionCommandRequest request)
        {
            Request = request;
        }
    }
}
