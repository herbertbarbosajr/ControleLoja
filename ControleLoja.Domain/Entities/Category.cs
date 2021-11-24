using ControleLoja.Domain.Validation;
using System;
using System.Collections.Generic;

namespace ControleLoja.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Nome { get; private set; }

        public Category(string nome)
        {
            ValidateDomain(Nome);
        }

        public Category(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(Nome);
        }

        public void Update(string nome)
        {
            ValidateDomain(Nome);
        }
        public ICollection<Product> Produtos { get; set; }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome Invalido.Nome é obrigatório.");

            DomainExceptionValidation.When(Nome.Length < 3,
               "Nome Invalido, minimo 3 caracteres");

            Nome = nome;
        }
    }
}
