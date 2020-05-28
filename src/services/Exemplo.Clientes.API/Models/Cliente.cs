using System;

namespace Exemplo.Clientes.API.Models
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        // EF Relation
        protected Cliente() { }

        public Cliente(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;

            // Não permitir gerar entidade em estado inválido
            // Validar();
        }


    }
}
