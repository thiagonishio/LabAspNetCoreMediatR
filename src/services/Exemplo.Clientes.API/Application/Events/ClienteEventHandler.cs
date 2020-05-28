using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo.Clientes.API.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine("Enviar evento de confirmação");
            return Task.CompletedTask;
        }
    }
}
