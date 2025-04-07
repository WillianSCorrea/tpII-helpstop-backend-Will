using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {


        #region Teste Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParamters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Create Category With Valid State Alone Name")]
        public void CreateCategory_WithValidAloneName_ResultObjectValidState()
        {
            Action action = () => new Category("Category Name");
            action.Should()
                .NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Teste Negativos

        [Fact(DisplayName = "Create Category With NameNull")]

        public void CreateCategory_WithNameNull_ResultObjectException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Category With Name Empty")]
        public void CreateCategory_WithNameEmpty_ResultObjectException()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Category With Name Too Short")]
        public void CreateCategory_WithNameTooShort_ResultObjectException()
        {
            Action action = () => new Category(1, "ab");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Id Invalid")]
        public void CreateCategory_WithIdInvalid_ResultObjectException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }


        #endregion
    

    
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName ="Create Category With Name Empty")]
        public void CreateCategory_WithNameEmpty_ResultObjetcException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        #endregion
    }
}
