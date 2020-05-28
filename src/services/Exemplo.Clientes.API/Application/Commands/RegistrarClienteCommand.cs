using Exemplo.Core.Messages;
using FluentValidation;
using System;

namespace Exemplo.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
        {
            public RegistrarClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.Cpf)
                    .NotEmpty()
                    .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("O e-mail informado não é válido.");
            }
        }
    }
}
