using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;

namespace Validators.Test.Expenses.Create;

public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new CreateExpenseValidator();
        var request = new RequestCreateExpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Description",
            Title = "Title",
            PaymentType = PaymentType.CreditCard
        };
        
        //Act
        var result = validator.Validate(request);


        //Assert
        Assert.True(result.IsValid);
    }
}