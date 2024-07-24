using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using cashFlow.Exception;
using CommonTestsUtils.Requests;
using FluentAssertions;

namespace Validators.Test.Expenses.Create;

public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new CreateExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        //Arrange
        var validator = new CreateExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }
}