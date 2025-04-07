using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HelpApp.Domain.Entities;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {

        #region Teste Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParamters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "abcde", 100, 1, "image");
            action.Should()
                .NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

        }
        #endregion




        #region Teste Negativos
        [Fact(DisplayName = "Create Product With Name Empty")]

        public void CreateProduct_WithNameEmpty_ResultObjectException()
        {
            Action action = () => new Product(1, "", "abcde", 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With NameNull")]

        public void CreateProduct_WithNameNull_ResultObjectException()
        {
            Action action = () => new Product(1, null, "abcde", 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }



        [Fact(DisplayName = "Create Product With Name Too Short")]
        public void CreateProduct_WithNameTooShort_ResultObjectException()
        {
            Action action = () => new Product(1, "ab", "abcde", 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }



        [Fact(DisplayName = "Create Product With Description Empty")]
        public void CreateProduct_WithDescriptionEmpty_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "", 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, name is required.");
        }
        [Fact(DisplayName = "Create Product With Description Null")]
        public void CreateProduct_WithDescriptionNull_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", null, 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, name is required.");
        }



        [Fact(DisplayName = "Create Product With Description Too Short ")]
        public void CreateProduct_WithDescriptionTooShort_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "abcd", 100, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }




        [Theory(DisplayName = "Create Product With Price Negative")]
        [InlineData(-1)]
        public void CreateProduct_WithPriceNegative_ResultObjectException(int invalid)
        {
            Action action = () => new Product(1, "Product Name", "abcde", invalid, 1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }


        [Theory(DisplayName = "Create Product With Stock Negative Stock")]
        [InlineData(-31)]
        public void CreateProduct_WithStockNegative_ResultObjectException(int invalid)
        {
            Action action = () => new Product(1, "Product Name", "abcde", 100, invalid, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }
        
        [Theory(DisplayName = "Create Product With URL Image Too Long")]
        [InlineData("https://www.example.com/bsbdfsdhfsybdjhfgyuihgsnlljajosnjagomnuhvrhnuvgyygcygudhauiqiasasdfghjklpoiuytrewqzxcvbnmlkjhgfdsaqweruiopplkjhgfdszxcvbnmlkjhgfdsaqwertyuioplkjhgfdsazxcvbnmmlkjhgfdsaqwertyuioplkjhgfdsazxcvbnmqwertyuiopasdfghjklzxcvbnm,qwertyuiopasdfghjklzxcvbnmetew")]
        public void CreateProduct_WithImageTooLong_ResultObjectException(string url )
        {
            Action action = () => new Product(1, "Product Name", "abcde", 100, 1, url
                ); action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact(DisplayName = "Create Product With Image empty")]
        public void CreateProduct_WithImageEmpty_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "abcde", 100, 1, ""
                ); action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, image is required.");
        }

        
        #endregion
    }
}
