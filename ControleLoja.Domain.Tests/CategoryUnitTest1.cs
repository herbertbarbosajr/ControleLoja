using ControleLoja.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace ControleLoja.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Cria categoria e valida estado.")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Nome da Categoria");
            action.Should()
                 .NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Nome da Categoria ");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Valor incorreto.");
        }

        [Fact]
        public void CreateCategory_ShortNomeValue_DomainExceptionShortNome()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Nome, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNomeValue_DomainExceptionRequiredNome()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Nome.Nome is required");
        }

        [Fact]
        public void CreateCategory_WithNullNomeValue_DomainExceptionInvalidNome()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
