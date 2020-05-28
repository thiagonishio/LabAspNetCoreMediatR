using Exemplo.Clientes.API.Application.Events;
using Exemplo.Clientes.API.Models;
using Exemplo.Core.Mediator;
using Exemplo.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ClienteCommandHandler(IMediatorHandler mediatorHandler)
        {
            // Injetar o repositório para registrar o cliente no banco de dados
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            // Implementar Registrar o cliente via repositório

            await _mediatorHandler.PublicarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            // Commit com Unit of Work

            return message.ValidationResult;
        }
    }
}
