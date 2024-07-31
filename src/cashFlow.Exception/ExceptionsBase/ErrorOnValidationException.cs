using System.Net;

namespace cashFlow.Exception.ExceptionsBase;

public class ErrorOnValidationException(List<string> errorMessages) : CashFlowException(string.Empty)
{
    private readonly List<string> _errors = errorMessages;
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors()
    {
        return _errors;
    }
}