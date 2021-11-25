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
            Action action = () => new Category(1, "Name da Categoria");
            action.Should()
                 .NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Name da Categoria ");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Valor incorreto.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name.Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
