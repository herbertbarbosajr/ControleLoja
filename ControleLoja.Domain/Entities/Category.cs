using ControleLoja.Domain.Validation;
using System;
using System.Collections.Generic;

namespace ControleLoja.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Product> Produtos { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Name Invalido.Name é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
               "Name Invalido, minimo 3 caracteres");

            Name = name;
        }
    }
}
