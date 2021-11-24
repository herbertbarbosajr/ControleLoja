using ControleLoja.Domain.Validation;
using System.Text.Json.Serialization;

namespace ControleLoja.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Nome { get; private set; }
        public string Descrição { get; private set; }
        public decimal Preço { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }

        public Product(string nome, string descrição, decimal preço, int estoque, string imagem)
        {
            ValidateDomain(Nome, Descrição, Preço, Estoque, Imagem);
        }

        public Product(int id, string nome, string descrição, decimal preço, int estoque, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Valor invalido.");
            Id = id;
            ValidateDomain(Nome, Descrição, Preço, Estoque, Imagem);
        }

        public void Update(string nome, string descrição, decimal preço, int estoque, string imagem, int categoriaId)
        {
            ValidateDomain(Nome, Descrição, Preço, Estoque, Imagem);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string descrição, decimal preço, int estoque, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Nome), 
                "Invalid Nome. Nome is required");

            DomainExceptionValidation.When(Nome.Length < 3,
                "Invalid Nome, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(Descrição),
                "Invalid Descrição. Descrição is required");

            DomainExceptionValidation.When(Descrição.Length < 5, 
                "Invalid Descrição, too short, minimum 5 characters");

            DomainExceptionValidation.When(Preço < 0, "Invalid Preço value");

            DomainExceptionValidation.When(Estoque < 0, "Invalid Estoque value");

            DomainExceptionValidation.When(Imagem?.Length > 250,
                "Invalid Imagem Nome, too long, maximum 250 characters");

            Nome = nome;
            Descrição = descrição;
            Preço = preço;
            Estoque = estoque;
            Imagem = imagem;

        }

        public int CategoriaId { get; set; }

        public Category Category { get; set; }
    }
}
