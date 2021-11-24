using ControleLoja.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace ControleLoja.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Nome do Produto", "Product Descrição do Produto", 9.99m,
                99, "product Imagem");
            action.Should()
                .NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Nome", "Product Descrição", 9.99m,
                99, "product Imagem");

            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNomeValue_DomainExceptionShortNome()
        {
            Action action = () => new Product(1, "Pr", "Product Descrição", 9.99m, 99,
                "product Imagem");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Nome, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_LongImagemNome_DomainExceptionLongImagemNome()
        {
            Action action = () => new Product(1, "Product Nome", "Product Descrição", 9.99m,
                99, "product Imagem toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Imagem Nome, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImagemNome_NoDomainException()
        {
            Action action = () => new Product(1, "Product Nome", "Product Descrição", 9.99m, 99, null);
            action.Should().NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImagemNome_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Nome", "Product Descrição", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact]
        public void CreateProduct_WithEmptyImagemNome_NoDomainException()
        {
            Action action = () => new Product(1, "Product Nome", "Product Descrição", 9.99m, 99, "");
            action.Should().NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPreçoValue_DomainException()
        {
            Action action = () => new Product(1, "Product Nome", "Product Descrição", -9.99m,
                99, "");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Preço value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidEstoqueValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Descrição", 9.99m, value,
                "product Imagem");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Estoque value");
        }

    }
}
