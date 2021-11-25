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
            Action action = () => new Product(1, "Name do Produto", "Product description do Produto", 9.99m,
                99, "product Image");
            action.Should()
                .NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 9.99m,
                99, "product Image");

            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 9.99m, 99,
                "product Image");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m,
                99, "product Image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Image Name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, null);
            action.Should().NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "");
            action.Should().NotThrow<ControleLoja.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", -9.99m,
                99, "");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product description", 9.99m, value,
                "product Image");
            action.Should().Throw<ControleLoja.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Stock value");
        }

    }
}
