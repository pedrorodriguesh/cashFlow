using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
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
}