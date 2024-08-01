using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using cashFlow.Exception;
using CommonTestsUtils.Requests;
using FluentAssertions;

namespace Validators.Test.Expenses.Create;

// unit tests
public class ExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseValidator();
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
        var validator = new ExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }
    
    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(2);
        
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.DATE_MUST_BE_IN_FUTURE));
    }
    
    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700;
        
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new ExpenseValidator();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Amount = amount;
        
        //Act
        var result = validator.Validate(request);

        //Assert
        // Using FluentAssertions package to make the test more readable
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
}