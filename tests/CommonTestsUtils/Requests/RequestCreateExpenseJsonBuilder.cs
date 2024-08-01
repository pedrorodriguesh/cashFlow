using Bogus;
using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;

namespace CommonTestsUtils.Requests;

public class RequestCreateExpenseJsonBuilder
{
    // Creating fake data with Bogus package
    public static RequestExpenseJson Build()
    {
        return new Faker<RequestExpenseJson>() // fluent sintaxe
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Amount, faker => faker.Finance.Amount())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}