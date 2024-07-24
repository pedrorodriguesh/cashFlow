using Bogus;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;

namespace CommonTestsUtils.Requests;

public class RequestCreateExpenseJsonBuilder
{
    public RequestCreateExpenseJson Build()
    {
        return new Faker<RequestCreateExpenseJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Amount, faker => faker.Finance.Amount())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}